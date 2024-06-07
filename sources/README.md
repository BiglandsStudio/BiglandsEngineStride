BiglandsEngine Sources
=============

Folders and projects layout
---------------------------

### core ###

* __BiglandsEngine.Core__:
   Reference counting, dependency property system (PropertyContainer/PropertyKey), low-level serialization, low-level memory operations (Utilities and NativeStream).
* __BiglandsEngine.Core.Mathematics__:
   Mathematics library (despite its name, no dependencies on BiglandsEngine.Core).
* __BiglandsEngine.Core.IO__:
   Virtual File System.
* __BiglandsEngine.Core.Serialization__:
   High-level serialization and git-like CAS storage system.
* __BiglandsEngine.Core.MicroThreading__:
   Micro-threading library based on C# 5.0 async (a.k.a. stackless programming)
* __BiglandsEngine.Core.AssemblyProcessor__:
   Internal tool used to patch assemblies to add various features, such as Serialization auto-generation, various memory/pinning operations, module initializers, etc...
   
### presentation ###

* __BiglandsEngine.Core.Presentation__: WPF UI library (themes, controls such as propertygrid, behaviors, etc...)
* __BiglandsEngine.Core.SampleApp__: Simple property grid example.
* __BiglandsEngine.Core.Quantum__: Advanced ViewModel library that gives ability to synchronize view-models over network (w/ diff), and at requested time intervals. That way, view models can be defined within engine without any UI dependencies.

### buildengine ###

* __BiglandsEngine.Core.BuildEngine.Common__:
   Common parts of the build engine. It can be reused to add new build steps, build commands, and also to build a new custom build engine client.
* __BiglandsEngine.Core.BuildEngine__: Default implementation of build engine tool (executable)

### shader ###

* __Irony__: Parsing library, used by BiglandsEngine.Core.Shaders. Should later be replaced by ANTLR4.
* __BiglandsEngine.Core.Shaders__: Shader parsing, type analysis and conversion library (used by HLSL->GLSL and BiglandsEngine Shader Language)
* __Irony.GrammarExplorer__: As the name suggests, language syntax tester, you can check how [BiglandsEngine Shading Language (SDSL)](https://doc.BiglandsEngine3d.net/latest/en/manual/graphics/effects-and-shaders/shading-language/index.html) works or test the newly introduced features

### targets ###

* MSBuild target files to create easily cross-platform solutions (Android, iOS, WinRT, etc...), and define behaviors and targets globally. Extensible.

----------

Use in your project
-------------------

### Source repository ###

There is two options to integrate this repository in your own repository:

* __git subtree__ [documentation](https://github.com/git/git/blob/master/contrib/subtree/git-subtree.txt) and [blog post](http://psionides.eu/2010/02/04/sharing-code-between-projects-with-git-subtree/)
* __git submodule__

### Basic use ###

Simply add the projects you want to use directly in your Visual Studio solution.

### Optional: Activate assembly processor ###

If you want to use auto-generated `Serialization` code, some of `Utilities` functions or `ModuleInitializer`, you need to use __BiglandsEngine.Core.AssemblyProcessor__.

Steps:

* Include both __BiglandsEngine.Core.AssemblyProcessor__ and __BiglandsEngine.Core.AssemblyProcessor.Common__ in your solution.
* Add either a __BiglandsEngine.Core.PostSettings.Local.targets__ or a __YourSolutionName.PostSettings.Local.targets__ in your solution folder, with this content:

```xml
<!-- Build file pre-included automatically by all projects in the solution -->
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <!-- Enable assembly processor -->
    <BiglandsEngineAssemblyProcessorGlobal>true</BiglandsEngineAssemblyProcessorGlobal>
  </PropertyGroup>
</Project>
```
