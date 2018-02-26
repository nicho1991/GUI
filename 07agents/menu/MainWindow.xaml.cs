﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace menu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Button cmd = (Button) e.OriginalSource;
            // Create an instance of the window named
            // by the current button.
            Type type = this.GetType();
            Assembly assembly = type.Assembly;
            Window win = (Window)assembly.CreateInstance(
                type.Namespace + "." + cmd.Content);

            // Show the window.
            win.ShowDialog();
        }


        private void Slider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ImageBrush brush = (ImageBrush)this.Resources["TileBrushh"];
            brush.Viewport = new Rect(0, 0, slider.Value, slider.Value);
            brush.Stretch = Stretch.Fill;
        }
    }
}
