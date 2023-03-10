using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube_DL_App.Mvvm;

namespace Youtube_DL_App.ViewModel
{
    /// <summary>
    /// Main window view model.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private OptionsViewModel? options = new OptionsViewModel();

        private string? url = string.Empty;

        public MainViewModel()
        {
            this.DownloadCommand = new RelayCommand(this.DownloadUrl, this.CanDownloadUrl);
        }

        public RelayCommand DownloadCommand { get; set; }

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
    }
}
