// <copyright file="ColorSpaceBase{TColorSpace}.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Colors.Spaces
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Base class for encapsulating common functionality
    /// for all colors spaces.
    /// </summary>
    /// <typeparam name="TColorSpace">The type of the specific color space.</typeparam>
    public abstract class ColorSpaceBase<TColorSpace> : IEquatable<TColorSpace>, IAlmostEquatable<TColorSpace, float>
        where TColorSpace : ColorSpaceBase<TColorSpace>
    {
        /// <summary>
        /// Gets or sets the backing vector for SIMD support.
        /// </summary>
        protected Vector4 BackingVector { get; set; }

        /// <inheritdoc />
        public bool AlmostEquals(TColorSpace other, float precision)
        {
            Vector4 result = Vector4.Abs(this.BackingVector - other.BackingVector);

            return result.X < precision
                && result.Y < precision
                && result.Z < precision;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is TColorSpace)
            {
                return this.Equals((TColorSpace)obj);
            }

            return false;
        }

        /// <inheritdoc />
        public bool Equals(TColorSpace other)
        {
            return this.AlmostEquals(other, ColorSpacesConstants.Epsilon);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.BackingVector.GetHashCode();
        }
    }
}
