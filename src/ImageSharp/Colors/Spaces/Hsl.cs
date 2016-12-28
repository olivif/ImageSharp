// <copyright file="Hsl.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Colors.Spaces
{
    using System;
    using System.ComponentModel;
    using System.Numerics;

    /// <summary>
    /// Represents a Hsl (hue, saturation, lightness) color.
    /// </summary>
    public class Hsl : ColorSpaceBase<Hsl>
    {
        /// <summary>
        /// Represents a <see cref="Hsl"/> that has H, S, and L values set to zero.
        /// </summary>
        public static readonly Hsl Empty = default(Hsl);

        /// <summary>
        /// Initializes a new instance of the <see cref="Hsl"/> class.
        /// </summary>
        /// <param name="h">The h hue component.</param>
        /// <param name="s">The s saturation component.</param>
        /// <param name="l">The l value (lightness) component.</param>
        public Hsl(float h, float s, float l)
        {
            this.BackingVector = Vector4.Clamp(
                new Vector4(h, s, l, 0),
                Vector4.Zero,
                new Vector4(360, 1, 1, 0));
        }

        /// <summary>
        /// Gets the hue component.
        /// <remarks>A value ranging between 0 and 360.</remarks>
        /// </summary>
        public float H => this.BackingVector.X;

        /// <summary>
        /// Gets the saturation component.
        /// <remarks>A value ranging between 0 and 1.</remarks>
        /// </summary>
        public float S => this.BackingVector.Y;

        /// <summary>
        /// Gets the lightness component.
        /// <remarks>A value ranging between 0 and 1.</remarks>
        /// </summary>
        public float L => this.BackingVector.Z;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Hsl"/> is empty.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsEmpty => this.Equals(Empty);

        /// <summary>
        /// Allows the implicit conversion of an instance of <see cref="Color"/> to a
        /// <see cref="Hsl"/>.
        /// </summary>
        /// <param name="color">The instance of <see cref="Color"/> to convert.</param>
        /// <returns>
        /// An instance of <see cref="Hsl"/>.
        /// </returns>
        public static implicit operator Hsl(Color color)
        {
            float r = color.R / 255F;
            float g = color.G / 255F;
            float b = color.B / 255F;

            float max = Math.Max(r, Math.Max(g, b));
            float min = Math.Min(r, Math.Min(g, b));
            float chroma = max - min;
            float h = 0;
            float s = 0;
            float l = (max + min) / 2;

            if (Math.Abs(chroma) < ColorSpacesConstants.Epsilon)
            {
                return new Hsl(0, s, l);
            }

            if (Math.Abs(r - max) < ColorSpacesConstants.Epsilon)
            {
                h = (g - b) / chroma;
            }
            else if (Math.Abs(g - max) < ColorSpacesConstants.Epsilon)
            {
                h = 2 + ((b - r) / chroma);
            }
            else if (Math.Abs(b - max) < ColorSpacesConstants.Epsilon)
            {
                h = 4 + ((r - g) / chroma);
            }

            h *= 60;
            if (h < 0.0)
            {
                h += 360;
            }

            if (l <= .5f)
            {
                s = chroma / (max + min);
            }
            else
            {
                s = chroma / (2 - chroma);
            }

            return new Hsl(h, s, l);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (this.IsEmpty)
            {
                return "Hsl [ Empty ]";
            }

            return $"Hsl [ H={this.H:#0.##}, S={this.S:#0.##}, L={this.L:#0.##} ]";
        }
    }
}
