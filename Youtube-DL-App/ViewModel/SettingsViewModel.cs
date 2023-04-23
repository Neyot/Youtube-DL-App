using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Youtube_DL_App.Interfaces;
using Youtube_DL_App.Mvvm;
using Youtube_DL_Wrapper.Interfaces;

namespace Youtube_DL_App.ViewModel
{
    /// <summary>
    /// Settings window view model.
    /// </summary>
    public class SettingsViewModel : ViewModelBase
    {
        /// <summary>
        /// Binary location helper.
        /// </summary>
        private readonly IBinaryHelper binaryHelper;

        /// <summary>
        /// Child window and dialog service.
        /// </summary>
        private readonly IWindowService windowService;

        /// <summary>
        /// Current binary path.
        /// </summary>
        private string? binaryPath = Properties.Settings.Default.BinaryPath;

        /// <summary>
        /// Initialises a new instance of the <see cref="SettingsViewModel"/> class.
        /// </summary>
        /// <param name="binaryHelper">Binary location helper.</param>
        public SettingsViewModel(IBinaryHelper binaryHelper, IWindowService windowService)
        {
            this.binaryHelper = binaryHelper ?? throw new ArgumentNullException(nameof(binaryHelper));
            this.windowService = windowService ?? throw new ArgumentNullException(nameof(windowService));

            this.BrowseForBinaryCommand = new RelayCommand(this.BrowseForBinary);
        }

        /// <summary>
        /// Browse for binary command handler.
        /// </summary>
        public RelayCommand BrowseForBinaryCommand { get; set; }

        /// <summary>
        /// Get or set the value of the binary path setting.
        /// </summary>
        public string? BinaryPath
        {
            get => this.binaryPath;
            set
            {
                if (this.binaryHelper.TrySetBinaryPath(value) == true)
                {
                    if (this.Set(ref this.binaryPath, value) == true)
                    {
                        Properties.Settings.Default.BinaryPath = value;
                        Properties.Settings.Default.Save();
                    }
                }
                else
                {
                    // Path selected by user is not valid. TODO: Notify them.
                }
            }
        }

        /// <summary>
        /// Open a file dialog for the user to specify the binary file location.
        /// </summary>
        /// <param name="notUsed">This parameter is not used.</param>
        public void BrowseForBinary(object? notUsed)
        {
            if (this.windowService.OpenFileDialog("Executables (*.exe)|*.exe|All files (*.*)|*.*", out string result) == true)
            {
                this.BinaryPath = result;
            }
        }
    }
}
