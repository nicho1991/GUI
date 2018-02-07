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

namespace Hull_Speed
{
    /// <summary>
    /// Interaction logic for maryPopup.xaml
    /// </summary>
    public partial class maryPopup : Window
    {
        private readonly MainWindow _mParent;
        public maryPopup(MainWindow oldWindow)
        {
            _mParent = oldWindow;
            
            
            InitializeComponent();
            //namelabel.Content = _mParent.texttest;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _mParent.Show();
           this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            namelabel.Content = _mParent.texttest.Text;
        }
    }
}
