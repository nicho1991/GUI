using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace DependencyProb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            hi.MouseDoubleClick += new MouseButtonEventHandler(test_mouseDouble);

        }

        private void over(object sender, RoutedEventArgs e)
        {
            hi.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void Hi_OnMouseLeave(object sender, MouseEventArgs e)
        {
            hi.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void test_mouseDouble(object sender, MouseEventArgs e)
        {
            hi.Foreground = new SolidColorBrush(Colors.Blue);
        }
    }


}
