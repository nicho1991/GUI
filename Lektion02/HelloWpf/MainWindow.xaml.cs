using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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

namespace HelloWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int test = 0;
        public MainWindow()
        {
            InitializeComponent();
            lol.MouseEnter += btnLol;

            box1.Content = 0;
            
        }

        private void btnLol(object sender, RoutedEventArgs e)
        {
            Random target = new Random();
            TranslateTransform flyt = new TranslateTransform(target.Next(-280,280),target.Next(-280,280));
            lol.RenderTransform = flyt;
            box1.Content = test++;

            //if (box1.Visibility == Visibility.Visible)
            //    box1.Visibility = Visibility.Hidden;
            //else
            //    box1.Visibility = Visibility.Visible;
        }
    }
}
