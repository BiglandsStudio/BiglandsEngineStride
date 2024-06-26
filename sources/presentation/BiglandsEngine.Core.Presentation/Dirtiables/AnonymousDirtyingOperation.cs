// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

namespace BiglandsEngine.Core.Presentation.Dirtiables;

public class AnonymousDirtyingOperation : DirtyingOperation
{
    private Action? undo;
    private Action? redo;

    public AnonymousDirtyingOperation(IEnumerable<IDirtiable> dirtiables, Action? undo, Action? redo)
        : base(dirtiables)
    {
        this.undo = undo;
        this.redo = redo;
    }

    /// <inheritdoc/>
    protected override void FreezeContent()
    {
        undo = null;
        redo = null;
    }

    /// <inheritdoc/>
    protected override void Undo()
    {
        undo?.Invoke();
    }

    /// <inheritdoc/>
    protected override void Redo()
    {
        redo?.Invoke();
    }
}
