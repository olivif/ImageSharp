// <copyright file="Bgra32.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Colors.Spaces
{
    using System.ComponentModel;
    using System.Numerics;

    /// <summary>
    /// Represents an BGRA (blue, green, red, alpha) color.
    /// </summary>
    public class Bgra32 : ColorSpaceBase<Bgra32>
    {
        /// <summary>
        /// Represents a 32 bit <see cref="Bgra32"/> that has B, G, R, and A values set to zero.
        /// </summary>
        public static readonly Bgra32 Empty = default(Bgra32);

        /// <summary>
        /// Initializes a new instance of the <see cref="Bgra32"/> class.
        /// </summary>
        /// <param name="b">The blue component of this <see cref="Bgra32"/>.</param>
        /// <param name="g">The green component of this <see cref="Bgra32"/>.</param>
        /// <param name="r">The red component of this <see cref="Bgra32"/>.</param>
        /// <param name="a">The alpha component of this <see cref="Bgra32"/>.</param>
        public Bgra32(byte b, byte g, byte r, byte a = 255)
        {
            this.BackingVector = Vector4.Clamp(new Vector4(b, g, r, a), Vector4.Zero, new Vector4(255));
        }

        /// <summary>
        /// Gets the blue component of the color
        /// </summary>
        public byte B => (byte)this.BackingVector.X;

        /// <summary>
        /// Gets the green component of the color
        /// </summary>
        public byte G => (byte)this.BackingVector.Y;

        /// <summary>
        /// Gets the red component of the color
        /// </summary>
        public byte R => (byte)this.BackingVector.Z;

        /// <summary>
        /// Gets the alpha component of the color
        /// </summary>
        public byte A => (byte)this.BackingVector.W;

        /// <summary>
        /// Gets the <see cref="Bgra32"/> integer representation of the color.
        /// </summary>
        public int Bgra => (this.R << 16) | (this.G << 8) | (this.B << 0) | (this.A << 24);

        /// <summary>
        /// Gets a value indicating whether this <see cref="Bgra32"/> is empty.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsEmpty => this.Equals(Empty);

        /// <summary>
        /// Allows the implicit conversion of an instance of <see cref="Color"/> to a
        /// <see cref="Bgra32"/>.
        /// </summary>
        /// <param name="color">
        /// The instance of <see cref="Color"/> to convert.
        /// </param>
        /// <returns>
        /// An instance of <see cref="Bgra32"/>.
        /// </returns>
        public static implicit operator Bgra32(Color color)
        {
            return new Bgra32(color.B, color.G, color.R, color.A);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (this.IsEmpty)
            {
                return "Bgra32 [ Empty ]";
            }

            return $"Bgra32 [ B={this.B}, G={this.G}, R={this.R}, A={this.A} ]";
        }
    }
}
