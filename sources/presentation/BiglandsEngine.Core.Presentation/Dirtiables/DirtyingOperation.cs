// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using BiglandsEngine.Core.Transactions;

namespace BiglandsEngine.Core.Presentation.Dirtiables;

public abstract class DirtyingOperation : Operation, IDirtyingOperation
{
    protected DirtyingOperation(IEnumerable<IDirtiable> dirtiables)
    {
        ArgumentNullException.ThrowIfNull(dirtiables);

        IsDone = true;
        Dirtiables = dirtiables.ToList();
    }

    /// <inheritdoc/>
    public bool IsDone { get; private set; }

    /// <inheritdoc/>
    public override bool HasEffect => true;

    /// <inheritdoc/>
    public IReadOnlyList<IDirtiable> Dirtiables { get; }

    /// <summary>
    /// Indicates whether this operation affects the same dirtiable objects that the given operation.
    /// </summary>
    /// <param name="otherOperation">The operation for which to compare dirtiables.</param>
    /// <returns><c>True</c> if this operation affects the same dirtiable objects that the given operation, <c>False</c> otherwise.</returns>
    public bool HasSameDirtiables(DirtyingOperation otherOperation)
    {
        if (otherOperation.Dirtiables.Count != Dirtiables.Count)
            return false;

        foreach (var dirtiable in Dirtiables)
        {
            if (!otherOperation.Dirtiables.Contains(dirtiable))
                return false;
        }
        return true;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{{{GetType().Name}}}";
    }

    /// <inheritdoc/>
    protected sealed override void Rollback()
    {
        Undo();
        IsDone = false;
    }

    /// <inheritdoc/>
    protected sealed override void Rollforward()
    {
        Redo();
        IsDone = true;
    }

    protected abstract void Undo();

    protected abstract void Redo();
}
