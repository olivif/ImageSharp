// <copyright file="CachedFileFixture.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Tests.TestUtilities
{
    using Xunit;

    /// <summary>
    /// Defines a collection of CachedFileFixture which can be shared
    /// across multiple test classes.
    /// </summary>
    [CollectionDefinition("Cached file collection")]
    public class CachedFileFixtureCollectionBase : ICollectionFixture<CachedFileFixture>
    {
    }
}
