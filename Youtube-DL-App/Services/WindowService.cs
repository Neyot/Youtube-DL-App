using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Youtube_DL_App.Interfaces;
using Youtube_DL_App.View;
using Youtube_DL_App.ViewModel;

namespace Youtube_DL_App.Services
{
    /// <summary>
    /// Service managing the application's child windows and dialogs.
    /// </summary>
    public class WindowService : IWindowService
    {
        /// <inheritdoc/>
        public bool? OpenSettingsDialog()
        {
            var dialog = new SettingsWindow();
            return dialog?.ShowDialog();
        }

        /// <inheritdoc/>
        public bool? OpenFileDialog(string filter, out string result)
        {
            var fileDialog = new OpenFileDialog
            {
                Filter = filter,
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == true)
            {
                result = fileDialog.FileName;
                return true;
            }
            else
            {
                result = string.Empty;
                return false;
            }
        }

        /// <inheritdoc/>
        public MessageBoxResult OpenMessageDialog(
            string message, 
            string caption, 
            MessageBoxButton button = MessageBoxButton.OK, 
            MessageBoxImage icon = MessageBoxImage.None, 
            MessageBoxResult defaultResult = MessageBoxResult.None, 
            MessageBoxOptions options = MessageBoxOptions.DefaultDesktopOnly)
        {
            return MessageBox.Show(message, caption, button, icon, defaultResult, options);
        }
    }
}
