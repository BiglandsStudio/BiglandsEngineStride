// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
namespace BiglandsEngine.Core.Shaders.Grammar
{
    /// <summary>
    /// Key terminal
    /// </summary>
    public class TokenInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenInfo"/> class.
        /// </summary>
        public TokenInfo()
        {
            IsCaseInsensitive = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenInfo"/> class.
        /// </summary>
        /// <param name="tokenCategory">The token category.</param>
        public TokenInfo(TokenCategory tokenCategory)
        {
            TokenCategory = tokenCategory;
            IsCaseInsensitive = false;
        }

        /// <summary>
        /// Gets or sets the token category.
        /// </summary>
        /// <value>
        /// The token category.
        /// </value>
        public TokenCategory TokenCategory { get; set; }

        /// <summary>
        /// Gets or sets if this token is case insensitive (default false).
        /// </summary>
        public bool IsCaseInsensitive { get; set; }

    }
}

