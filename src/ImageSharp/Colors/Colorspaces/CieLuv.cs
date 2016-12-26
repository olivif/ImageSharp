// <copyright file="CieLuv.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Colors.Colorspaces
{
    using System;

    /// <summary>
    /// CieLuv - https://en.wikipedia.org/wiki/CIELUV
    /// </summary>
    public struct CieLuv : IEquatable<CieLuv>, IAlmostEquatable<CieLuv, float>
    {
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
