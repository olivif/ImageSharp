﻿// <copyright file="GeneralFormatTests.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Tests
{
    using System;
    using System.IO;
    using TestUtilities;

    using Xunit;

    public class GeneralFormatTests : FileTestBase
    {
        private readonly CachedFileFixture testFiles;

        public GeneralFormatTests()
        {
            this.testFiles = new CachedFileFixture(); ;
        }

        [Fact]
        public void ResolutionShouldChange()
        {
            string path = CreateOutputDirectory("Resolution");

            foreach (TestFile file in Files)
            {
                Image image = file.CreateImage();

                FileStream output = this.testFiles.GetFileStream($"{path}/{file.FileName}");

                image.VerticalResolution = 150;
                image.HorizontalResolution = 150;
                image.Save(output);
            }
        }

        [Fact]
        public void ImageCanEncodeToString()
        {
            string path = CreateOutputDirectory("ToString");

            foreach (TestFile file in Files)
            {
                Image image = file.CreateImage();

                string filename = path + "/" + file.FileNameWithoutExtension + ".txt";
                File.WriteAllText(filename, image.ToBase64String());
            }
        }

        [Fact]
        public void DecodeThenEncodeImageFromStreamShouldSucceed()
        {
            string path = CreateOutputDirectory("Encode");

            foreach (TestFile file in Files)
            {
                Image image = file.CreateImage();

                //var image = file.CreateImage()
                //    .To<Bgr565, ushort>()
                //    .To<Bgra4444, ushort>()
                //    .To<Bgra5551, ushort>()
                //    .To<Byte4, uint>()
                //    .To<HalfSingle, ushort>()
                //    .To<HalfVector2, uint>()
                //    .To<HalfVector4, ulong>()
                //    .To<Rg32, uint>()
                //    .To<Rgba1010102, uint>()
                //    .To<NormalizedByte2, ushort>()
                //    .To<NormalizedByte4, uint>()
                //    .To<NormalizedShort2, uint>()
                //    .To<NormalizedShort4, ulong>()
                //    .To<Short2, uint>()
                //    .To<Short4, ulong>();

                // Image<Bgr565, ushort> image = file.CreateImage().To<Bgr565, ushort>();
                // Image<Bgra4444, ushort> image = file.CreateImage().To<Bgra4444, ushort>();
                // Image<Bgra5551, ushort> image = file.CreateImage().To<Bgra5551, ushort>();
                // Image<Byte4, uint> image = file.CreateImage().To<Byte4, uint>();
                // Image<HalfSingle, ushort> image = file.CreateImage().To<HalfSingle, ushort>();
                // Image<HalfVector2, uint> image = file.CreateImage().To<HalfVector2, uint>();
                // Image<HalfVector4, ulong> image = file.CreateImage().To<HalfVector4, ulong>();
                // Image<Rg32, uint> image = file.CreateImage().To<Rg32, uint>();
                // Image<Rgba1010102, uint> image = file.CreateImage().To<Rgba1010102, uint>();
                // Image<Rgba64, ulong> image = file.CreateImage().To<Rgba64, ulong>();
                // Image<NormalizedByte2, ushort> image = file.CreateImage().To<NormalizedByte2, ushort>();
                // Image<NormalizedByte4, uint> image = file.CreateImage().To<NormalizedByte4, uint>();
                // Image<NormalizedShort2, uint> image = file.CreateImage().To<NormalizedShort2, uint>();
                // Image<NormalizedShort4, ulong> image = file.CreateImage().To<NormalizedShort4, ulong>();
                // Image<Short2, uint> image = file.CreateImage().To<Short2, uint>();
                // Image<Short4, ulong> image = file.CreateImage().To<Short4, ulong>();
                FileStream output = this.testFiles.GetFileStream($"{path}/{file.FileName}");
               
                image.Save(output);
            }
        }

        [Fact]
        public void QuantizeImageShouldPreserveMaximumColorPrecision()
        {
            string path = CreateOutputDirectory("Quantize");

            foreach (TestFile file in Files)
            {
                Image image = file.CreateImage();

                // Copy the original pixels to save decoding time.
                Color[] pixels = new Color[image.Width * image.Height];
                Array.Copy(image.Pixels, pixels, image.Pixels.Length);

                using (FileStream output = this.testFiles.GetFileStream($"{path}/Octree-{file.FileName}"))
                {
                    image.Quantize(Quantization.Octree)
                          .Save(output, image.CurrentImageFormat);

                }

                image.SetPixels(image.Width, image.Height, pixels);
                using (FileStream output = this.testFiles.GetFileStream($"{path}/Wu-{file.FileName}"))
                {
                    image.Quantize(Quantization.Wu)
                          .Save(output, image.CurrentImageFormat);
                }

                image.SetPixels(image.Width, image.Height, pixels);
                using (FileStream output = this.testFiles.GetFileStream($"{path}/Palette-{file.FileName}"))
                {
                    image.Quantize(Quantization.Palette)
                          .Save(output, image.CurrentImageFormat);
                }
            }
        }

        [Fact]
        public void ImageCanConvertFormat()
        {
            string path = CreateOutputDirectory("Format");

            foreach (TestFile file in Files)
            {
                Image image = file.CreateImage();

                {
                    FileStream output = this.testFiles.GetFileStream($"{path}/{file.FileNameWithoutExtension}.gif");
                    image.SaveAsGif(output);
                }

                {
                    FileStream output = this.testFiles.GetFileStream($"{path}/{file.FileNameWithoutExtension}.bmp");
                    image.SaveAsBmp(output);
                }

                {
                    FileStream output = this.testFiles.GetFileStream($"{path}/{file.FileNameWithoutExtension}.jpg");
                    image.SaveAsJpeg(output);
                }

                {
                    FileStream output = this.testFiles.GetFileStream($"{path}/{file.FileNameWithoutExtension}.png");
                    image.SaveAsPng(output);
                }
            }
        }

        [Fact]
        public void ImageShouldPreservePixelByteOrderWhenSerialized()
        {
            string path = CreateOutputDirectory("Serialized");

            foreach (TestFile file in Files)
            {
                Image image = file.CreateImage();

                byte[] serialized;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream);
                    memoryStream.Flush();
                    serialized = memoryStream.ToArray();
                }

                using (MemoryStream memoryStream = new MemoryStream(serialized))
                {
                    Image image2 = new Image(memoryStream);

                    FileStream output = this.testFiles.GetFileStream($"{path}/{file.FileName}");

                    image2.Save(output);
                }
            }
        }
    }
}