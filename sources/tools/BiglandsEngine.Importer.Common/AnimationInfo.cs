// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using System.Collections.Generic;
using BiglandsEngine.Animations;

namespace BiglandsEngine.Importer.Common
{
    public class AnimationInfo
    {
        public TimeSpan Duration;
        public Dictionary<string, AnimationClip> AnimationClips = new();
    }
}
