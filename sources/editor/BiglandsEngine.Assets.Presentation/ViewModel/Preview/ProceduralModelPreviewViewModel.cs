// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using Stride.Core.Assets.Editor.ViewModel;
using Stride.Core.Presentation.Commands;
using Stride.Assets.Presentation.Preview;
using Stride.Editor.Annotations;
using Stride.Editor.Preview;

namespace Stride.Assets.Presentation.ViewModel.Preview
{
    [AssetPreviewViewModel<ProceduralModelPreview>]
    public class ProceduralModelPreviewViewModel : AssetPreviewViewModel
    {
        private ProceduralModelPreview modelPreview;

        public ProceduralModelPreviewViewModel(SessionViewModel session)
            : base(session)
        {
            ResetModelCommand = new AnonymousCommand(ServiceProvider, ResetModel);
        }

        public ICommandBase ResetModelCommand { get; }

        public override void AttachPreview(IAssetPreview preview)
        {
            modelPreview = (ProceduralModelPreview)preview;
        }

        private void ResetModel()
        {
            modelPreview?.ResetCamera();
        }
    }
}
