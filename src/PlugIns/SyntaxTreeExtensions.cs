﻿// <copyright file="SyntaxTreeExtensions.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.PlugIns
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;

    /// <summary>
    /// Extensions for <see cref="SyntaxTree"/>s.
    /// </summary>
    public static class SyntaxTreeExtensions
    {
        private static IList<PortableExecutableReference> assemblyReferences;

        private static IList<PortableExecutableReference> AssemblyReferences
        {
            get
            {
                if (assemblyReferences is { })
                {
                    return assemblyReferences;
                }

                var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => !a.IsDynamic)
                    .Select(a => a.Location)
                    .ToHashSet();
                var separator = (Environment.OSVersion.Platform == PlatformID.MacOSX ||
                                 Environment.OSVersion.Platform == PlatformID.Unix)
                    ? ':'
                    : ';';

                assemblyReferences = (AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES") as string)
                    ?.Split(separator)
                    .Select(path => MetadataReference.CreateFromFile(path))
                    .Where(metaData => loadedAssemblies.Contains(metaData.FilePath))
                    .ToList();
                return assemblyReferences;
            }
        }

        /// <summary>
        /// Compiles the <see cref="SyntaxTree"/> and load its assembly into memory.
        /// </summary>
        /// <param name="syntaxTree">The syntax tree.</param>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <returns>The compiled assembly.</returns>
        public static Assembly CompileAndLoad(this SyntaxTree syntaxTree, string assemblyName)
        {
            var options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                .WithOverflowChecks(false)
                .WithOptimizationLevel(OptimizationLevel.Release)
                .WithUsings("System", "System.Collections.Generic");
            var compilation = CSharpCompilation.Create(assemblyName, new[] { syntaxTree }, AssemblyReferences, options);
            using var stream = new MemoryStream();
            var result = compilation.Emit(stream);
            if (!result.Success)
            {
                var stringBuilder = new StringBuilder();
                result.Diagnostics
                    .Where(m => m.Severity == DiagnosticSeverity.Error)
                    .Select(d => $"{d.GetMessage()} @ {d.Location}")
                    .ToList()
                    .ForEach(message => stringBuilder.AppendLine(message));
                throw new ArgumentException(stringBuilder.ToString());
            }

            return Assembly.Load(stream.ToArray());
        }
    }
}
