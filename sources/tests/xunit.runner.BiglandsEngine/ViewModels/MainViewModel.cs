// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

namespace xunit.runner.BiglandsEngine.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {

    }

    public TestsViewModel Tests { get; } = new TestsViewModel();
}
