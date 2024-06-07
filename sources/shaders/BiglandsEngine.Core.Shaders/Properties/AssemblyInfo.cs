// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System.Reflection;
using System.Runtime.CompilerServices;


#pragma warning disable 436 // BiglandsEngine.PublicKeys is defined in multiple assemblies

[assembly: InternalsVisibleTo("BiglandsEngine.Core.Shaders.Serializers" + BiglandsEngine.PublicKeys.Default)]
