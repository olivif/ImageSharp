﻿// <copyright file="BitmapTests.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

using ImageSharp.Formats;

namespace ImageSharp.Tests
{
    using System.IO;

    using Formats;
    using ImageSharp.Formats.Bmp;
    using Xunit;

    public class BitmapTests : FileTestBase
    {
        public static readonly TheoryData<BmpBitsPerPixel> BitsPerPixel
        = new TheoryData<BmpBitsPerPixel>
        {
            BmpBitsPerPixel.Pixel24 ,
            BmpBitsPerPixel.Pixel32
        };

        [Theory]
        [MemberData("BitsPerPixel")]
        public void BitmapCanEncodeDifferentBitRates(BmpBitsPerPixel bitsPerPixel)
        {
            string path = CreateOutputDirectory("Bmp");

            foreach (TestFile file in Files)
            {
                string filename = file.GetFileNameWithoutExtension(bitsPerPixel);
                Image image = file.CreateImage();

                using (FileStream output = File.OpenWrite($"{path}/{filename}.bmp"))
                {
                    var options = new BmpEncoderOptions
                    {
                        BitsPerPixel = bitsPerPixel
                    };
                    var encoder = new BmpEncoder
                    {
                        EncoderOptions = options
                    };
                    image.Save(output, encoder);
                }
            }
        }
    }
}