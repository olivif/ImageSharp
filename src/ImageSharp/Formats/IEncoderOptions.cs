// <copyright file="IEncoderOptions.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Formats
{
    using ImageSharp.Quantizers;

    /// <summary>
    /// Encoder options
    /// </summary>
    public interface IEncoderOptions
    {
        /// <summary>
        /// Gets or sets the quality of output for images.
        /// </summary>
        int Quality { get; set; }

        /// <summary>
        /// Gets or sets the quantizer for reducing the color count.
        /// </summary>
        IQuantizer Quantizer { get; set; }
    }
}
