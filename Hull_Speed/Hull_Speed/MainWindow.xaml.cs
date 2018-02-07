using System;
using System.Windows;
using System.Windows.Input;

namespace Hull_Speed
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            thewindow.KeyDown += smaller; //metode 1 I KODE
            sailboatimg.MouseDown += img_click;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var sail = new Sailboat();
            try
            {
                sail.Length = int.Parse(lengthBox.Text);
                knotsBox.Text = sail.Hullspeed().ToString();
            }
            catch (Exception exception)
            {
                knotsBox.Text = "only numbers!";
            }
            
            
        }

        private void bigger(object sender, KeyEventArgs e) // Metode 2 , i xaml og kode.
        {
            if (e.Key == Key.L && Keyboard.Modifiers == ModifierKeys.Control)
            {
                if (thewindow.FontSize < 36) thewindow.FontSize += 2;
                e.Handled = true;
            }
        }

        private void smaller(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S && Keyboard.Modifiers == ModifierKeys.Control)
            {
                if (thewindow.FontSize > 8) thewindow.FontSize -= 2;
                e.Handled = true;
            }
        }

        private void img_click(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("The name of the boat is: " + texttest.Text);

          
            this.Hide();
            maryPopup win2 = new maryPopup(this);
            win2.Show();
            
        }
    }
}