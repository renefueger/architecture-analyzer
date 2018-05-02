﻿
namespace ArchitectureAnalyzer.DotnetScanner.Model
{
    using System.Collections.Generic;

    using ArchitectureAnalyzer.Core.Graph;

    using Newtonsoft.Json;

    public class NetAssembly : Node
    {
        public string Name { get; set; }

        [JsonIgnore]
        public IList<NetAssembly> References { get; set; }

        [JsonIgnore]
        public IList<NetType> DefinedTypes { get; set; }

        public NetAssembly(string id) : base(id)
        {
            References = new List<NetAssembly>();
            DefinedTypes = new List<NetType>();
        }
    }
}
