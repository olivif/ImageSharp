// <copyright file="CachedFileFixture.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>
namespace ImageSharp.Tests.TestUtilities
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;

    public class CachedFileFixture : IDisposable
    {
        private IDictionary<string, FileStream> fileStreams;

        public CachedFileFixture()
        {
            this.fileStreams = new ConcurrentDictionary<string, FileStream>();
        }

        public FileStream GetFileStream(string path)
        {
            if (!this.fileStreams.ContainsKey(path))
            {
                this.fileStreams.Add(path, File.OpenWrite(path));
            }

            return this.fileStreams[path];
        }

        public void Dispose()
        {
            foreach(var fileStream in this.fileStreams)
            {
                fileStream.Value.Dispose();
            }
        }
    }
}
