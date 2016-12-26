// <copyright file="CieLuv.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Colors.Colorspaces
{
    using System;
    using System.Numerics;

    /// <summary>
    /// CieLuv - https://en.wikipedia.org/wiki/CIELUV
    /// </summary>
    public struct CieLuv : IEquatable<CieLuv>, IAlmostEquatable<CieLuv, float>
    {
        /// <summary>
        /// The backing vector for SIMD support.
        /// </summary>
        private Vector3 backingVector;

        /// <summary>
        /// Lightness component
        /// <remarks>
        /// A value ranging between 0 and 100.
        /// http://cs.haifa.ac.il/hagit/courses/ist/Lectures/Demos/ColorApplet/me/infoluv.html
        /// </remarks>
        /// </summary>
        public float L => this.backingVector.X;

        /// <summary>
        /// U component
        /// <remarks>
        /// A value ranging between -134 and 220.
        /// http://cs.haifa.ac.il/hagit/courses/ist/Lectures/Demos/ColorApplet/me/infoluv.html
        /// </remarks>
        /// </summary>
        public float U => this.backingVector.Y;

        /// <summary>
        /// V component
        /// <remarks>
        /// A value ranging between -140 and 122.
        /// http://cs.haifa.ac.il/hagit/courses/ist/Lectures/Demos/ColorApplet/me/infoluv.html
        /// </remarks>
        /// </summary>
        public float V => this.backingVector.Z;

        /// <inheritdoc/>
        public bool AlmostEquals(CieLuv other, float precision)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool Equals(CieLuv other)
        {
            throw new NotImplementedException();
        }
    }
}
