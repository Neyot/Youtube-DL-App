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

namespace Youtube_DL_App {
    /// <summary>
    /// Interaction logic for ConsoleLogWindow.xaml
    /// </summary>
    public partial class ConsoleLogWindow : Window {
        public ConsoleLogWindow() {
            InitializeComponent();
        }

        private void JumpToBottomButton_Click(object sender, RoutedEventArgs e) {
            this.ConsoleLogTextBox.ScrollToEnd();
        }
    }
}
