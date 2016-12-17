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

    /// <summary>
    /// Responsible for keeping all test file streams in memory and lazily fetching them
    /// the first time they are needed.
    /// </summary>
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
                Console.WriteLine("Opening file stream {0}", path);
            }
            else
            {
                Console.WriteLine("File stream {0} already there", path);
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
