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
    public class WindowService : IWindowService
    {
        public bool? OpenSettingsDialog()
        {
            var dialog = new SettingsWindow();
            return dialog?.ShowDialog();
        }
    }
}
