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
        /// Lightness X
        /// </summary>
        public float Lx => this.backingVector.X;

        /// <summary>
        /// Lightness Y
        /// </summary>
        public float Ly => this.backingVector.Y;

        /// <summary>
        /// Lightness Z
        /// </summary>
        public float Lz => this.backingVector.Z;

        /// <summary>
        /// Illuminant value
        /// </summary>
        public string Illuminant;

        /// <summary>
        /// Default illuminant value
        /// </summary>
        private const string DefaultIlluminant = "D65";

        /// <summary>
        /// Observer value
        /// </summary>
        public int Observer;

        /// <summary>
        /// Default observer value
        /// </summary>
        private const int DefaultObserver = 2;

        /// <summary>
        /// Initializes a new instance of the <see cref="CieLuv"/> class.
        /// </summary>
        /// <param name="lx">Lightness x</param>
        /// <param name="ly">Lightness y</param>
        /// <param name="lz">Lightness z</param>
        public CieLuv(float lx, float ly, float lz)
            : this(lx, ly, lz, DefaultIlluminant, DefaultObserver)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CieLuv"/> class.
        /// </summary>
        /// <param name="lx">Lightness x</param>
        /// <param name="ly">Lightness y</param>
        /// <param name="lz">Lightness z</param>
        /// <param name="illuminant">Illuminant</param>
        /// <param name="observer">Observer</param>
        public CieLuv(float lx, float ly, float lz, string illuminant, int observer)
        {
            this.backingVector = new Vector3(lx, ly, lz);

            this.Illuminant = illuminant;
            this.Observer = observer;
        }

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
