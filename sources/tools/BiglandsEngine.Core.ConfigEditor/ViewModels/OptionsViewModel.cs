// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.IO;
using System.Windows;
using BiglandsEngine.Core.Presentation.Commands;
using BiglandsEngine.Core.Presentation.ViewModel;

namespace BiglandsEngine.ConfigEditor.ViewModels
{
    public class OptionsViewModel : ViewModelBase
    {
        public Options Options { get; private set; }

        public OptionsViewModel()
        {
            Options = Options.Load() ?? new Options();

            BiglandsEnginePath = Options.BiglandsEnginePath;
            BiglandsEngineConfigFilename = Options.BiglandsEngineConfigFilename;

            CheckBiglandsEnginePath();
            CheckBiglandsEngineConfigFilename();

            BrowsePathCommand = new AnonymousCommand(BrowsePath);
            BrowseConfigFileCommand = new AnonymousCommand(BrowseConfigFile);
        }

        public void SetOptionsWindow(Window window)
        {
            CloseCommand = new AnonymousCommand(window.Close);
        }

        public ICommand CloseCommand { get; private set; }
        public ICommand BrowsePathCommand { get; private set; }
        public ICommand BrowseConfigFileCommand { get; private set; }

        private void BrowsePath()
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog
            {
                Description = "Select BiglandsEngine base directory",
                ShowNewFolderButton = true,
            };

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                BiglandsEnginePath = dialog.SelectedPath;
        }

        private void BrowseConfigFile()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Title = "Select the BiglandsEngine configuration file",
                Filter = "Xml Files (*.xml)|*.xml|All Files (*.*)|*.*",
                Multiselect = false,
                CheckFileExists = true,
            };

            if (dialog.ShowDialog() == true)
                BiglandsEngineConfigFilename = dialog.FileName;
        }

        private string BiglandsEnginePath;
        public string BiglandsEnginePath
        {
            get { return BiglandsEnginePath; }
            set
            {
                if (SetValue(ref BiglandsEnginePath, value, "BiglandsEnginePath"))
                    CheckBiglandsEnginePath();
            }
        }

        private bool isBiglandsEnginePathValid;
        public bool IsBiglandsEnginePathValid
        {
            get { return isBiglandsEnginePathValid; }
            set { SetValue(ref isBiglandsEnginePathValid, value, "IsBiglandsEnginePathValid"); }
        }

        private void CheckBiglandsEnginePath()
        {
            IsBiglandsEnginePathValid = Directory.Exists(BiglandsEnginePath);
        }

        private string BiglandsEngineConfigFilename;
        public string BiglandsEngineConfigFilename
        {
            get { return BiglandsEngineConfigFilename; }
            set
            {
                if (SetValue(ref BiglandsEngineConfigFilename, value, "BiglandsEngineConfigFilename"))
                    CheckBiglandsEngineConfigFilename();
            }
        }

        private bool isBiglandsEngineConfigFilenameValid;
        public bool IsBiglandsEngineConfigFilenameValid
        {
            get { return isBiglandsEngineConfigFilenameValid; }
            set { SetValue(ref isBiglandsEngineConfigFilenameValid, value, "IsBiglandsEngineConfigFilenameValid"); }
        }

        private void CheckBiglandsEngineConfigFilename()
        {
            if (string.IsNullOrWhiteSpace(BiglandsEngineConfigFilename))
            {
                IsBiglandsEngineConfigFilenameValid = true;
                return;
            }

            var tempFilename = BiglandsEngineConfigFilename;

            if (Path.IsPathRooted(tempFilename) == false)
                tempFilename = Path.Combine(BiglandsEnginePath, BiglandsEngineConfigFilename);

            IsBiglandsEngineConfigFilenameValid = File.Exists(tempFilename);
        }

        private ICommand acceptCommand;
        public ICommand AcceptCommand
        {
            get
            {
                if (acceptCommand == null)
                    acceptCommand = new AnonymousCommand(Accept);
                return acceptCommand;
            }
        }

        private void Accept()
        {
            if (string.IsNullOrWhiteSpace(BiglandsEnginePath))
            {
                MessageBox.Show("Invalid BiglandsEngine Path, this field must not be empty.", "BiglandsEngine Path Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Directory.Exists(BiglandsEnginePath) == false)
            {
                string message = string.Format("Invalid BiglandsEngine Path, the directory '{0}' does not exit.", BiglandsEnginePath);
                MessageBox.Show(message, "BiglandsEngine Path Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Options.BiglandsEnginePath = BiglandsEnginePath;
            Options.BiglandsEngineConfigFilename = BiglandsEngineConfigFilename;

            Options.Save();

            var handler = OptionsChanged;
            if (handler != null)
                handler();

            CloseCommand.Execute(null); // this just closes the Options window
        }

        public event Action OptionsChanged;
    }
}
