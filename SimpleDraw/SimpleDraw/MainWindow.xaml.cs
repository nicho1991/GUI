using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace SimpleDraw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void ColorCombo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ComboBoxItem cmb = (ComboBoxItem) ColorCombo.SelectedItem;
            ColorCombo.Background = cmb.Background;
            App.Current.MainWindow.Focus();
        }

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.B)
            {
                ColorCombo.SelectedIndex = 1;
            }

            if (e.Key == Key.V)
            {
                ColorCombo.SelectedIndex = 0;
            }

            if (e.Key == Key.N)
            {
                ColorCombo.SelectedIndex = 2;
            }
        }

        public Point currentPoint = new Point();

        private void Canvas_OnMouseMove(object sender, MouseEventArgs e)
        {
            Regex regex = new Regex(";");
            string MousePos = e.GetPosition(this).ToString();
            string[] mousePoss = regex.Split(MousePos);

            XMouse.Text = mousePoss[0];
            YMouse.Text = mousePoss[1];

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line();

                line.Stroke = SystemColors.WindowFrameBrush;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;

                currentPoint = e.GetPosition(this);

                Canvas.Children.Add(line);

            }
        }

        private void Canvas_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);
        }
    }
}
