using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Youtube_DL_App.ViewModel;

namespace Youtube_DL_App.View
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            this.InitializeComponent();

            this.Owner = App.Current.Services.GetService<MainWindow>();
            this.DataContext = App.Current.Services.GetService<SettingsViewModel>();
        }

        /// <summary>
        /// View model as strongly-typed data context.
        /// </summary>
        public SettingsViewModel ViewModel => (SettingsViewModel)this.DataContext;
    }
}
