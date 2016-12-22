// <copyright file="BmpEncoder.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Formats
{
    using System;
    using System.IO;
    using Bmp;

    /// <summary>
    /// Image encoder for writing an image to a stream as a Windows bitmap.
    /// </summary>
    /// <remarks>The encoder can currently only write 24-bit rgb images to streams.</remarks>
    public class BmpEncoder : IImageEncoder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BmpEncoder"/> class.
        /// </summary>
        public BmpEncoder()
        {
            this.EncoderOptions = new BmpEncoderOptions();
        }

        /// <inheritdoc/>
        public IEncoderOptions EncoderOptions { get; set; }

        /// <inheritdoc/>
        public void Encode<TColor, TPacked>(Image<TColor, TPacked> image, Stream stream)
            where TColor : struct, IPackedPixel<TPacked>
            where TPacked : struct, IEquatable<TPacked>
        {
            BmpEncoderCore encoder = new BmpEncoderCore();
            BmpEncoderOptions encoderOptions = this.EncoderOptions as BmpEncoderOptions;
            encoder.Encode(image, stream, encoderOptions);
        }
    }
}
