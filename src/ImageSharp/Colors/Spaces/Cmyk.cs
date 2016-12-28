// <copyright file="Cmyk.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Colors.Spaces
{
    using System;
    using System.ComponentModel;
    using System.Numerics;

    /// <summary>
    /// Represents an CMYK (cyan, magenta, yellow, keyline) color.
    /// </summary>
    public class Cmyk : ColorSpaceBase<Cmyk>
    {
        /// <summary>
        /// Represents a <see cref="Cmyk"/> that has C, M, Y, and K values set to zero.
        /// </summary>
        public static readonly Cmyk Empty = default(Cmyk);

        /// <summary>
        /// Initializes a new instance of the <see cref="Cmyk"/> class.
        /// </summary>
        /// <param name="c">The cyan component.</param>
        /// <param name="m">The magenta component.</param>
        /// <param name="y">The yellow component.</param>
        /// <param name="k">The keyline black component.</param>
        public Cmyk(float c, float m, float y, float k)
        {
            this.BackingVector = Vector4.Clamp(
                new Vector4(c, m, y, k),
                Vector4.Zero,
                Vector4.One);
        }

        /// <summary>
        /// Gets the cyan color component.
        /// <remarks>A value ranging between 0 and 1.</remarks>
        /// </summary>
        public float C => this.BackingVector.X;

        /// <summary>
        /// Gets the magenta color component.
        /// <remarks>A value ranging between 0 and 1.</remarks>
        /// </summary>
        public float M => this.BackingVector.Y;

        /// <summary>
        /// Gets the yellow color component.
        /// <remarks>A value ranging between 0 and 1.</remarks>
        /// </summary>
        public float Y => this.BackingVector.Z;

        /// <summary>
        /// Gets the keyline black color component.
        /// <remarks>A value ranging between 0 and 1.</remarks>
        /// </summary>
        public float K => this.BackingVector.W;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Cmyk"/> is empty.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsEmpty => this.Equals(Empty);

        /// <summary>
        /// Allows the implicit conversion of an instance of <see cref="Color"/> to a
        /// <see cref="Cmyk"/>.
        /// </summary>
        /// <param name="color">
        /// The instance of <see cref="Bgra32"/> to convert.
        /// </param>
        /// <returns>
        /// An instance of <see cref="Cmyk"/>.
        /// </returns>
        public static implicit operator Cmyk(Color color)
        {
            float c = 1f - (color.R / 255F);
            float m = 1f - (color.G / 255F);
            float y = 1f - (color.B / 255F);

            float k = Math.Min(c, Math.Min(m, y));

            if (Math.Abs(k - 1.0f) <= ColorSpacesConstants.Epsilon)
            {
                return new Cmyk(0, 0, 0, 1);
            }

            c = (c - k) / (1 - k);
            m = (m - k) / (1 - k);
            y = (y - k) / (1 - k);

            return new Cmyk(c, m, y, k);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (this.IsEmpty)
            {
                return "Cmyk [Empty]";
            }

            return $"Cmyk [ C={this.C:#0.##}, M={this.M:#0.##}, Y={this.Y:#0.##}, K={this.K:#0.##}]";
        }
    }
}
