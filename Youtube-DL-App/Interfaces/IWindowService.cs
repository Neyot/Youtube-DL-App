using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Youtube_DL_App.Interfaces
{
    /// <summary>
    /// Service managing the application's child windows and dialogs.
    /// </summary>
    public interface IWindowService
    {
        /// <summary>
        /// Open the Settings dialog.
        /// </summary>
        /// <returns><see langword="true"/> if the dialog opened successfully; otherwise, <see langword="false"/>.</returns>
        bool? OpenSettingsDialog();

        /// <summary>
        /// Open a file dialog for the user to specify a file location.
        /// </summary>
        /// <param name="filter">Filter string to limit user to choosing specific files.</param>
        /// <param name="result">User-specified file location.</param>
        /// <returns><see langword="true"/> if the user specified a valid file; otherwise, <see langword="false"/>.</returns>
        bool? OpenFileDialog(string filter, out string result);

        /// <summary>
        /// Open a message dialog to display a message to the user.
        /// </summary>
        MessageBoxResult OpenMessageDialog(string message, string caption, MessageBoxButton button = MessageBoxButton.OK, MessageBoxImage icon = MessageBoxImage.None, MessageBoxResult defaultResult = MessageBoxResult.None, MessageBoxOptions options = MessageBoxOptions.DefaultDesktopOnly);
    }
}
