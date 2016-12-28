// <copyright file="CieXyz.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Colors.Spaces
{
    using System.ComponentModel;
    using System.Numerics;

    /// <summary>
    /// Represents an CIE 1931 color
    /// <see href="https://en.wikipedia.org/wiki/CIE_1931_color_space"/>
    /// </summary>
    public class CieXyz : ColorSpaceBase<CieXyz>
    {
        /// <summary>
        /// Represents a <see cref="CieXyz"/> that has Y, Cb, and Cr values set to zero.
        /// </summary>
        public static readonly CieXyz Empty = default(CieXyz);

        /// <summary>
        /// Initializes a new instance of the <see cref="CieXyz"/> class.
        /// </summary>
        /// <param name="x">X is a mix (a linear combination) of cone response curves chosen to be nonnegative</param>
        /// <param name="y">The y luminance component.</param>
        /// <param name="z">Z is quasi-equal to blue stimulation, or the S cone of the human eye.</param>
        public CieXyz(float x, float y, float z)
        {
            // Not clamping as documentation about this space seems to indicate "usual" ranges
            this.BackingVector = new Vector4(x, y, z, 0);
        }

        /// <summary>
        /// Gets the Y luminance component.
        /// <remarks>A value ranging between 380 and 780.</remarks>
        /// </summary>
        public float X => this.BackingVector.X;

        /// <summary>
        /// Gets the Cb chroma component.
        /// <remarks>A value ranging between 380 and 780.</remarks>
        /// </summary>
        public float Y => this.BackingVector.Y;

        /// <summary>
        /// Gets the Cr chroma component.
        /// <remarks>A value ranging between 380 and 780.</remarks>
        /// </summary>
        public float Z => this.BackingVector.Z;

        /// <summary>
        /// Gets a value indicating whether this <see cref="CieXyz"/> is empty.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsEmpty => this.Equals(Empty);

        /// <summary>
        /// Allows the implicit conversion of an instance of <see cref="Color"/> to a
        /// <see cref="CieXyz"/>.
        /// </summary>
        /// <param name="color">
        /// The instance of <see cref="Color"/> to convert.
        /// </param>
        /// <returns>
        /// An instance of <see cref="CieXyz"/>.
        /// </returns>
        public static implicit operator CieXyz(Color color)
        {
            Vector4 vector = color.ToVector4().Expand();

            float x = (vector.X * 0.4124F) + (vector.Y * 0.3576F) + (vector.Z * 0.1805F);
            float y = (vector.X * 0.2126F) + (vector.Y * 0.7152F) + (vector.Z * 0.0722F);
            float z = (vector.X * 0.0193F) + (vector.Y * 0.1192F) + (vector.Z * 0.9505F);

            x *= 100F;
            y *= 100F;
            z *= 100F;

            return new CieXyz(x, y, z);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (this.IsEmpty)
            {
                return "CieXyz [ Empty ]";
            }

            return $"CieXyz [ X={this.X:#0.##}, Y={this.Y:#0.##}, Z={this.Z:#0.##} ]";
        }
    }
}
