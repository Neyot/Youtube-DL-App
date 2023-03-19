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
        private readonly IWindowService windowService;

        private OptionsViewModel? options = new OptionsViewModel();

        private string? url = string.Empty;

        public MainViewModel(IWindowService windowService)
        {
            this.windowService = windowService ?? throw new ArgumentNullException(nameof(windowService));

            this.DownloadCommand = new RelayCommand(this.DownloadUrl, this.CanDownloadUrl);
            this.OpenSettingsCommand = new RelayCommand(this.OpenSettings, this.CanOpenSettings);
        }

        public RelayCommand DownloadCommand { get; set; }

        public RelayCommand OpenSettingsCommand { get; set; }

        public OptionsViewModel? Options
        {
            get => this.options;
            set
            {
                this.Set(ref this.options, value);
            }
        }

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

        private bool CanOpenSettings(object? notUsed)
        {
            return true;
        }

        private void OpenSettings(object? notUsed)
        {
            this.windowService.OpenSettingsDialog();
        }
    }
}
