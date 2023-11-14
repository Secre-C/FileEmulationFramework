﻿using System;
using System.IO;
using Xunit;
using FileEmulationFramework.Lib.Utilities;
//using SPD.File.Emulator.Spd;
//using SPD.File.Emulator.Spr;
//using SPD.File.Emulator.Sprite;

namespace FileEmulationFramework.Tests.Emulators.SPD;

public class SpdEmulatorTests
{
    //[Fact]
    //public void ReplaceTextureSpd()
    //{
    //    var builder = new SpdBuilder();

    //    builder.AddOrReplaceFile(SpdAssets.ReplaceTex);

    //    RunBuilder(SpdAssets.Base, SpdAssets.ReplaceTexResult, SpdAssets.Result, builder);
    //}

    //[Fact]
    //public void ReplaceSpriteSpd()
    //{
    //    var builder = new SpdBuilder();

    //    builder.AddOrReplaceFile(SpdAssets.ReplaceSpriteTex);
    //    builder.AddOrReplaceFile(SpdAssets.ReplaceSpriteSpr);

    //    RunBuilder(SpdAssets.Base, SpdAssets.ReplaceSpriteResult, SpdAssets.Result, builder);
    //}

    //[Fact]
    //public void PatchSpriteSpd()
    //{
    //    var builder = new SpdBuilder();

    //    builder.AddOrReplaceFile(SpdAssets.PatchSprite);
    //    RunBuilder(SpdAssets.Base, SpdAssets.PatchSpriteResult, SpdAssets.Result, builder);
    //}

    //[Fact]
    //public void ReplaceTextureSpr()
    //{
    //    var builder = new SprBuilder();

    //    builder.AddOrReplaceFile(SprAssets.ReplaceTex);

    //    RunBuilder(SprAssets.Base, SprAssets.ReplaceTexResult, SprAssets.Result, builder);
    //}

    //[Fact]
    //public void ReplaceSpriteSpr()
    //{
    //    var builder = new SprBuilder();

    //    builder.AddOrReplaceFile(SprAssets.ReplaceSpriteTex);
    //    builder.AddOrReplaceFile(SprAssets.ReplaceSpriteSpr);

    //    RunBuilder(SprAssets.Base, SprAssets.ReplaceSpriteResult, SprAssets.Result, builder);
    //}

    //[Fact]
    //public void PatchSpriteSpr()
    //{
    //    var builder = new SprBuilder();

    //    builder.AddOrReplaceFile(SprAssets.PatchSprite);
    //    RunBuilder(SprAssets.Base, SprAssets.PatchSpriteResult, SprAssets.Result, builder);
    //}

    //public static void RunBuilder(string baseFile, string prebuiltResult, string buildResult, SpriteBuilder builder)
    //{
    //     var handle = Native.CreateFileW(baseFile, FileAccess.Read, FileShare.Read, IntPtr.Zero, FileMode.Open, FileAttributes.Normal, IntPtr.Zero);
    //    var stream = builder.Build(handle, baseFile);

    //    // Write to file for checking.
    //    using var fileStream = new FileStream(buildResult, FileMode.Create);
    //    stream.CopyTo(fileStream);
    //    fileStream.Close();

    //    // Parse file and check.
    //    Assert.Equal(File.ReadAllBytes(prebuiltResult), File.ReadAllBytes(buildResult));
    //}
}
