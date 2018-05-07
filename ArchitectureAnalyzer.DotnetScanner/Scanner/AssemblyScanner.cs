﻿
namespace ArchitectureAnalyzer.DotnetScanner.Scanner
{
    using System.Linq;
    using System.Reflection.Metadata;

    using ArchitectureAnalyzer.DotnetScanner.Model;
    using ArchitectureAnalyzer.DotnetScanner.Utils;

    using Microsoft.Extensions.Logging;

    internal class AssemblyScanner : AbstractScanner
    {
        public AssemblyScanner(
            MetadataReader reader,
            IModelFactory factory,
            ILogger logger)
            : base(reader, factory, logger)
        {
        }

        public NetAssembly Scan(AssemblyDefinition assembly)
        {
            var name = assembly.Name.GetString(Reader);

            var assemblyModel = Factory.CreateAssemblyModel(name);
            assemblyModel.Name = name;
            
            assemblyModel.References = Reader.AssemblyReferences
                .Select(Reader.GetAssemblyReference)
                .Select(CreateAssemblyModel)
                .ToList();
            
            var typeScanner = new TypeScanner(Reader, Factory, Logger);

            foreach (var type in Reader.TypeDefinitions.Select(Reader.GetTypeDefinition))
            {
                var typeModel = typeScanner.ScanType(type);
                if (typeModel == null)
                {
                    continue;
                }
                
                assemblyModel.DefinedTypes.Add(typeModel);
            }

            return assemblyModel;
        }

        private NetAssembly CreateAssemblyModel(AssemblyReference assemblyReference)
        {
            return Factory.CreateAssemblyModel(assemblyReference.Name.GetString(Reader));
        }
    }
}
