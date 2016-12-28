// <copyright file="Hsv.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Colors.Spaces
{
    using System;
    using System.ComponentModel;
    using System.Numerics;

    /// <summary>
    /// Represents a HSV (hue, saturation, value) color. Also known as HSB (hue, saturation, brightness).
    /// </summary>
    public class Hsv : ColorSpaceBase<Hsv>
    {
        /// <summary>
        /// Represents a <see cref="Hsv"/> that has H, S, and V values set to zero.
        /// </summary>
        public static readonly Hsv Empty = default(Hsv);

        /// <summary>
        /// Initializes a new instance of the <see cref="Hsv"/> class.
        /// </summary>
        /// <param name="h">The h hue component.</param>
        /// <param name="s">The s saturation component.</param>
        /// <param name="v">The v value (brightness) component.</param>
        public Hsv(float h, float s, float v)
        {
            this.BackingVector = Vector4.Clamp(
                new Vector4(h, s, v, 0),
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
        /// Gets the value (brightness) component.
        /// <remarks>A value ranging between 0 and 1.</remarks>
        /// </summary>
        public float V => this.BackingVector.Z;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Hsv"/> is empty.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsEmpty => this.Equals(Empty);

        /// <summary>
        /// Allows the implicit conversion of an instance of <see cref="Color"/> to a
        /// <see cref="Hsv"/>.
        /// </summary>
        /// <param name="color">The instance of <see cref="Color"/> to convert.</param>
        /// <returns>
        /// An instance of <see cref="Hsv"/>.
        /// </returns>
        public static implicit operator Hsv(Color color)
        {
            float r = color.R / 255F;
            float g = color.G / 255F;
            float b = color.B / 255F;

            float max = Math.Max(r, Math.Max(g, b));
            float min = Math.Min(r, Math.Min(g, b));
            float chroma = max - min;
            float h = 0;
            float s = 0;
            float v = max;

            if (Math.Abs(chroma) < ColorSpacesConstants.Epsilon)
            {
                return new Hsv(0, s, v);
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

            s = chroma / v;

            return new Hsv(h, s, v);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (this.IsEmpty)
            {
                return "Hsv [ Empty ]";
            }

            return $"Hsv [ H={this.H:#0.##}, S={this.S:#0.##}, V={this.V:#0.##} ]";
        }
    }
}
