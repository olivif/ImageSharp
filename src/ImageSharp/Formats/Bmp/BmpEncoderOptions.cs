// <copyright file="BmpEncoderOptions.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Formats.Bmp
{
    /// <summary>
    /// Bmp EncoderOptions
    /// </summary>
    public class BmpEncoderOptions : IEncoderOptions
    {
        /// <summary>
        /// Gets or sets the number of bits per pixel.
        /// </summary>
        public BmpBitsPerPixel BitsPerPixel { get; set; } = BmpBitsPerPixel.Pixel24;
    }
}
