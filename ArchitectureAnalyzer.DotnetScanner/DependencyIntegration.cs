﻿
namespace ArchitectureAnalyzer.DotnetScanner
{
    using System;

    using ArchitectureAnalyzer.Core.Scanner;
    using ArchitectureAnalyzer.DotnetScanner.Model;
    using ArchitectureAnalyzer.DotnetScanner.Scanner;

    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyIntegration
    {
        public static void AddDotnetScanner(this IServiceCollection services, Action<ReflectionScannerConfiguration> configure)
        {
            var config = new ReflectionScannerConfiguration();
            configure(config);

            services.AddSingleton(config);
            services.AddTransient<IScanner, ReflectionScanner>();
            services.AddTransient<IModelFactory, ModelFactory>();
        }
    }
}
