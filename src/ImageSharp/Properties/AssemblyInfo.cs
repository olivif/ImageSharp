﻿// <copyright file="AssemblyInfo.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("ImageSharp")]
[assembly: AssemblyDescription("A cross-platform library for processing of image files; written in C#")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("James Jackson-South")]
[assembly: AssemblyProduct("ImageSharp")]
[assembly: AssemblyCopyright("Copyright (c) James Jackson-South and contributors.")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: NeutralResourcesLanguage("en")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0.0")]

// Ensure the internals can be tested.
[assembly: InternalsVisibleTo("ImageSharp.Benchmarks")]
[assembly: InternalsVisibleTo("ImageSharp.Tests")]
[assembly: InternalsVisibleTo("ImageSharp.Tests46")]
