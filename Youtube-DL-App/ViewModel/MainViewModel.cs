using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube_DL_App.Interfaces;
using Youtube_DL_App.Mvvm;

namespace Youtube_DL_App.ViewModel
{
    /// <summary>
    /// Main window view model.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Child window and dialog service.
        /// </summary>
        private readonly IWindowService windowService;

        /// <summary>
        /// Options viewport view model.
        /// </summary>
        private OptionsViewModel? options = new();

        /// <summary>
        /// URL to attempt to download with the selected options.
        /// </summary>
        private string? url = string.Empty;

        /// <summary>
        /// Initialises a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="windowService">Child window and dialog service.</param>
        public MainViewModel(IWindowService windowService)
        {
            this.windowService = windowService ?? throw new ArgumentNullException(nameof(windowService));

            this.DownloadCommand = new RelayCommand(this.DownloadUrl, this.CanDownloadUrl);
            this.OpenSettingsCommand = new RelayCommand(this.OpenSettings, this.CanOpenSettings);
        }

        /// <summary>
        /// Download command handler.
        /// </summary>
        public RelayCommand DownloadCommand { get; set; }

        /// <summary>
        /// Open Settings Window command handler.
        /// </summary>
        public RelayCommand OpenSettingsCommand { get; set; }

        /// <summary>
        /// Gets or sets the options viewport view model.
        /// </summary>
        public OptionsViewModel? Options
        {
            get => this.options;
            set
            {
                this.Set(ref this.options, value);
            }
        }

        /// <summary>
        /// Gets or sets the URL to attempt to download with the selected options.
        /// </summary>
        public string? Url
        {
            get => this.url;
            set
            {
                this.Set(ref this.url, value);
            }
        }

        /// <summary>
        /// Can <see cref="Url"/> be downloaded with <see cref="Options"/> ?
        /// </summary>
        /// <param name="notUsed">This parameter is not used.</param>
        /// <returns><see langword="true"/> if allowed; otherwise, <see langword="false"/>.</returns>
        private bool CanDownloadUrl(object? notUsed)
        {
            return true;
        }

        /// <summary>
        /// Download <see cref="Url"/> with <see cref="Options"/> .
        /// </summary>
        /// <param name="notUsed">This parameter is not used.</param>
        private void DownloadUrl(object? notUsed)
        {

        }

        /// <summary>
        /// Can the Settings window be opened?
        /// </summary>
        /// <param name="notUsed">This parameter is not used.</param>
        /// <returns><see langword="true"/> if allowed; otherwise, <see langword="false"/>.</returns>
        private bool CanOpenSettings(object? notUsed)
        {
            return true;
        }

        /// <summary>
        /// Open the Settings window..
        /// </summary>
        /// <param name="notUsed">This parameter is not used.</param>
        private void OpenSettings(object? notUsed)
        {
            this.windowService.OpenSettingsDialog();
        }
    }
}
