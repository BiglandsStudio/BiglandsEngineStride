// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiglandsEngine.Framework.MicroThreading;
using System.Windows.Input;
using BiglandsEngine.Core.Presentation.Commands;
using BiglandsEngine.Core.Presentation;

namespace BiglandsEngine.DebugTools.ViewModels
{
    public class MicroThreadViewModel : DeprecatedViewModelBase
    {
        private readonly MicroThread microThread;

        public MicroThreadViewModel(MicroThread microThread)
        {
            if (microThread == null)
                throw new ArgumentNullException("microThread");

            if (microThread.Scheduler == null)
                throw new ArgumentException("Invalid Scheduler in MicroThread " + microThread.Id);

            this.microThread = microThread;

            // New MicroThread system doesn't have any PropertyChanged event yet.
            throw new NotImplementedException();
            //this.microThread.Scheduler.MicroThreadStateChanged += OnMicroThreadStateChanged;
        }

        private void OnMicroThreadStateChanged(object sender, SchedulerEventArgs e)
        {
            if (e.MicroThread == microThread)
            {
                OnPropertyChanged<MicroThreadViewModel>(n => n.State);
            }
        }

        public long Id
        {
            get
            {
                return microThread.Id;
            }
        }

        public string Name
        {
            get
            {
                return microThread.Name;
            }
        }

        public MicroThreadState State
        {
            get
            {
                return microThread.State;
            }
        }

        public Exception Exception
        {
            get
            {
                return microThread.Exception;
            }
        }
    }
}
