
using System;
using Mono.Addins;

[assembly:AddinRoot ("Core", 
        Namespace = "MonoDevelop", 
        Version = MonoDevelop.BuildInfo.Version,
        CompatVersion = MonoDevelop.BuildInfo.CompatVersion,
        Category = "MonoDevelop Core")]

[assembly: ExtensionPointAttribute(
    Path = "/MonoDevelop/ProjectModel/FileFormats",
    Name = "Solution file format handlers", 
    Description = "File format handlers for workspaces, solutions and projects",
    NodeName = "FileFormat",
    NodeType = typeof(MonoDevelop.Projects.Extensions.FileFormatNode))]
[assembly:AddinName ("MonoDevelop Runtime")]
[assembly:AddinDescription ("Provides the core services of the MonoDevelop platform")]
