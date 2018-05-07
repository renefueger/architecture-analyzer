﻿namespace ArchitectureAnalyzer.DotnetScanner.Scanner
{
    using System.Reflection.Metadata;
    
    using ArchitectureAnalyzer.DotnetScanner.Model;

    using Microsoft.Extensions.Logging;

    internal abstract class AbstractScanner
    {
        protected MetadataReader Reader { get; }

        protected IModelFactory Factory { get; }

        protected ILogger Logger { get; }

        protected AbstractScanner(MetadataReader reader, IModelFactory factory, ILogger logger)
        {
            Reader = reader;
            Factory = factory;
            Logger = logger;
        }
    }
}
