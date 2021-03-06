﻿// <copyright file="Quantize.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp
{
    using System;

    using ImageSharp.Quantizers;

    /// <summary>
    /// Extension methods for the <see cref="Image{TColor}"/> type.
    /// </summary>
    public static partial class ImageExtensions
    {
        /// <summary>
        /// Applies quantization to the image.
        /// </summary>
        /// <typeparam name="TColor">The pixel format.</typeparam>
        /// <param name="source">The image this method extends.</param>
        /// <param name="mode">The quantization mode to apply to perform the operation.</param>
        /// <param name="maxColors">The maximum number of colors to return. Defaults to 256.</param>
        /// <returns>The <see cref="Image{TColor}"/>.</returns>
        public static Image<TColor> Quantize<TColor>(this Image<TColor> source, Quantization mode = Quantization.Octree, int maxColors = 256)
            where TColor : struct, IPackedPixel, IEquatable<TColor>
        {
            IQuantizer<TColor> quantizer;
            switch (mode)
            {
                case Quantization.Wu:
                    quantizer = new WuQuantizer<TColor>();
                    break;

                case Quantization.Palette:
                    quantizer = new PaletteQuantizer<TColor>();
                    break;

                default:
                    quantizer = new OctreeQuantizer<TColor>();
                    break;
            }

            return Quantize(source, quantizer, maxColors);
        }

        /// <summary>
        /// Applies quantization to the image.
        /// </summary>
        /// <typeparam name="TColor">The pixel format.</typeparam>
        /// <param name="source">The image this method extends.</param>
        /// <param name="quantizer">The quantizer to apply to perform the operation.</param>
        /// <param name="maxColors">The maximum number of colors to return.</param>
        /// <returns>The <see cref="Image{TColor}"/>.</returns>
        public static Image<TColor> Quantize<TColor>(this Image<TColor> source, IQuantizer<TColor> quantizer, int maxColors)
            where TColor : struct, IPackedPixel, IEquatable<TColor>
        {
            QuantizedImage<TColor> quantizedImage = quantizer.Quantize(source, maxColors);
            source.SetPixels(source.Width, source.Height, quantizedImage.ToImage().Pixels);
            return source;
        }
    }
}
