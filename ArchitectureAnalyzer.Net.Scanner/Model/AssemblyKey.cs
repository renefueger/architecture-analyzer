﻿namespace ArchitectureAnalyzer.Net.Scanner.Model
{
    public struct AssemblyKey
    {
        public string Name { get; }

        public AssemblyKey(string name) : this()
        {
            Name = name;
        }
    }
}