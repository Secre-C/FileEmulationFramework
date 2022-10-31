﻿using System.Diagnostics;
using System.Runtime.CompilerServices;
using AWB.Stream.Emulator.Acb;
using AWB.Stream.Emulator.Template;
using FileEmulationFramework.Interfaces;
using FileEmulationFramework.Lib.Utilities;
using Reloaded.Memory.Sigscan.Definitions;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;

[module: SkipLocalsInit]
namespace AWB.Stream.Emulator;

/// <summary>
/// Your mod logic goes here.
/// </summary>
public class Mod : ModBase // <= Do not Remove.
{
    /// <summary>
    /// Provides access to the mod loader API.
    /// </summary>
    private readonly IModLoader _modLoader;

    /// <summary>
    /// Provides access to the Reloaded logger.
    /// </summary>
    private readonly ILogger _logger;

    /// <summary>
    /// Entry point into the mod, instance that created this class.
    /// </summary>
    private readonly IMod _owner;

    /// <summary>
    /// Provides access to this mod's configuration.
    /// </summary>
    private Config _configuration;

    /// <summary>
    /// The configuration of the currently executing mod.
    /// </summary>
    private readonly IModConfig _modConfig;

    private Logger _log;
    private AwbEmulator _awbEmulator;
    private AcbPatcherEmulator _acbEmulator;
    
    public Mod(ModContext context)
    {
        _modLoader = context.ModLoader;
        _logger = context.Logger;
        _owner = context.Owner;
        _configuration = context.Configuration;
        _modConfig = context.ModConfig;

        // For more information about this template, please see
        // https://reloaded-project.github.io/Reloaded-II/ModTemplate/

        // If you want to implement e.g. unload support in your mod,
        // and some other neat features, override the methods in ModBase.

        _modLoader.ModLoading += OnModLoading;
        _modLoader.OnModLoaderInitialized += OnModLoaderInitialized;
        _log = new Logger(_logger, _configuration.LogLevel);
        _log.Info("Starting AWB.Stream.Emulator");
        _awbEmulator = new AwbEmulator(_log, _configuration.DumpAwb);

        _modLoader.GetController<IEmulationFramework>().TryGetTarget(out var framework);
        framework!.Register(_awbEmulator);
        
        // Create ACB & BDX Overwriters
        _modLoader.GetController<IScannerFactory>().TryGetTarget(out var factory);
        _acbEmulator = new AcbPatcherEmulator(_awbEmulator, _log, factory, _configuration.CheckAcbExtension);
        framework!.Register(_acbEmulator);
    }
    
    private void OnModLoaderInitialized()
    {
        _modLoader.ModLoading -= OnModLoading;
        _modLoader.OnModLoaderInitialized -= OnModLoaderInitialized;
    }

    private void OnModLoading(IModV1 mod, IModConfigV1 modConfig) => _awbEmulator.OnModLoading(_modLoader.GetDirectoryForModId(modConfig.ModId));

    #region Standard Overrides
    public override void ConfigurationUpdated(Config configuration)
    {
        // Apply settings from configuration.
        // ... your code here.
        _configuration = configuration;
        _logger.WriteLine($"[{_modConfig.ModId}] Config Updated: Applying");
        _log.LogLevel = configuration.LogLevel;
        _configuration.DumpAwb = configuration.DumpAwb;
        _configuration.CheckAcbExtension = configuration.CheckAcbExtension;
    }
    #endregion

    #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Mod() { }
#pragma warning restore CS8618
    #endregion
}