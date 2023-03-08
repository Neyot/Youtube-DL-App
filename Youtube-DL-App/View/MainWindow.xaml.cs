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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;
using Youtube_DL_App.ViewModel;

namespace Youtube_DL_App.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="mainViewModel">Main window view model.</param>
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = App.Current.Services.GetService<MainViewModel>();
        }

        /// <summary>
        /// View model as strongly-typed data context.
        /// </summary>
        public MainViewModel ViewModel => (MainViewModel)this.DataContext;
    }
}
