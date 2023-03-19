using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
