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

namespace clicker
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int clicks = 0;
        public MainWindow()
        {
            InitializeComponent();
            Click.Click += clickHandler;

               
            
            
        }

        private void clickHandler(object sender, RoutedEventArgs e)
        {
            clicks++;
            Count.Content = clicks;
        }
    }
}
