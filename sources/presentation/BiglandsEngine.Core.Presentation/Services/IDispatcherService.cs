// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

namespace BiglandsEngine.Core.Presentation.Services;

/// <summary>
/// This interface allows to dispatch execution of a portion of code in the thread where it was created, usually the Main thread.
/// </summary>
public interface IDispatcherService
{
    /// <summary>
    /// Executes the given callback in the dispatcher thread. This method will block until the execution of the callback is completed.
    /// </summary>
    /// <param name="callback">The callback to execute in the dispatcher thread.</param>
    void Invoke(Action callback);

    /// <summary>
    /// Executes the given callback in the dispatcher thread. This method will block until the execution of the callback is completed.
    /// </summary>
    /// <typeparam name="TResult">The type of result returned by the callback.</typeparam>
    /// <param name="callback">The callback to execute in the dispatcher thread.</param>
    /// <returns>The result returned by the executed callback.</returns>
    TResult Invoke<TResult>(Func<TResult> callback);

    /// <summary>
    /// Executes the given asynchronous function in the dispatcher thread. This method will run asynchronously and return immediately.
    /// </summary>
    /// <param name="callback">The asynchronous function to execute in the dispatcher thread.</param>
    /// <returns>A task corresponding to the asynchronous execution of the given function.</returns>
    Task InvokeAsync(Action callback, CancellationToken token = default);

    /// <summary>
    /// Executes the given asynchronous function in the dispatcher thread. This method will run asynchronously and return immediately.
    /// </summary>
    /// <param name="callback">The asynchronous function to execute in the dispatcher thread.</param>
    /// <returns>A task corresponding to the asynchronous execution of the given function.</returns>
    /// <remarks>This method uses a low priority to schedule the action on the dispatcher thread.</remarks>
    Task LowPriorityInvokeAsync(Action callback, CancellationToken token = default);

    /// <summary>
    /// Executes the given asynchronous function in the dispatcher thread. This method will run asynchronously and return immediately.
    /// </summary>
    /// <typeparam name="TResult">The type of result returned by the task.</typeparam>
    /// <param name="callback">The asynchronous function to execute in the dispatcher thread.</param>
    /// <returns>A task corresponding to the asynchronous execution of the given task.</returns>
    Task<TResult> InvokeAsync<TResult>(Func<TResult> callback, CancellationToken token = default);

    /// <summary>
    /// Executes the given asynchronous task in the dispatcher thread. This method will run asynchronously and return immediately.
    /// </summary>
    /// <param name="task">The asynchronous task to execute in the dispatcher thread.</param>
    /// <returns>A task corresponding to the asynchronous execution of the given function.</returns>
    Task InvokeTask(Func<Task> task, CancellationToken token = default);

    /// <summary>
    /// Executes the given asynchronous task in the dispatcher thread. This method will run asynchronously and return immediately.
    /// </summary>
    /// <typeparam name="TResult">The type of result returned by the task.</typeparam>
    /// <param name="task">The asynchronous task to execute in the dispatcher thread.</param>
    /// <returns>A task corresponding to the asynchronous execution of the given task.</returns>
    Task<TResult> InvokeTask<TResult>(Func<Task<TResult>> task, CancellationToken token = default);

    /// <summary>
    /// Verifies that the current thread is the dispatcher thread.
    /// </summary>
    /// <returns><c>True</c> if the current thread is the dispatcher thread, <c>False</c> otherwise.</returns>
    bool CheckAccess();

    /// <summary>
    /// Ensures that the current thread is (or is not) the dispatcher thread. This method will throw an exception if it is not the case.
    /// </summary>
    void EnsureAccess(bool inDispatcherThread = true);
}
