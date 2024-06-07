// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using BiglandsEngine.Core.Shaders.Ast.Hlsl;

namespace BiglandsEngine.Core.Shaders.Ast.BiglandsEngine
{
    public partial class BiglandsEngineConstantBufferType : ConstantBufferType
    {
        /// <summary>
        ///   Resource group keyword (rgroup).
        /// </summary>
        public static readonly BiglandsEngineConstantBufferType ResourceGroup = new BiglandsEngineConstantBufferType("rgroup");

        /// <summary>
        /// Initializes a new instance of the <see cref="BiglandsEngineStorageQualifier"/> class.
        /// </summary>
        public BiglandsEngineConstantBufferType()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BiglandsEngineStorageQualifier"/> class.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        public BiglandsEngineConstantBufferType(string key)
            : base(key)
        {
        }

        /// <summary>
        /// Parses the specified enum name.
        /// </summary>
        /// <param name="enumName">
        /// Name of the enum.
        /// </param>
        /// <returns>
        /// A qualifier
        /// </returns>
        public static new ConstantBufferType Parse(string enumName)
        {
            if (enumName == (string)ResourceGroup.Key)
                return ResourceGroup;

            return ConstantBufferType.Parse(enumName);
        }
    }
}
