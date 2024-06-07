// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using BiglandsEngine.Core;
using BiglandsEngine.Core.Reflection;
using BiglandsEngine.Core.Translation;
using BiglandsEngine.Core.Translation.Providers;

namespace BiglandsEngine.Core.Presentation
{
    internal class Module
    {
        [ModuleInitializer]
        public static void Initialize()
        {
            AssemblyRegistry.Register(typeof(Module).Assembly, AssemblyCommonCategories.Assets);
            // Initialize translation
            TranslationManager.Instance.RegisterProvider(new GettextTranslationProvider());
        }
    }
}
