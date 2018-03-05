using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace _09Settings
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            if (_09Settings.Properties.Settings.Default.CallUpgrade)
            {
                _09Settings.Properties.Settings.Default.Upgrade();
                _09Settings.Properties.Settings.Default.CallUpgrade = false;
            }
        }

        private void App_OnExit(object sender, ExitEventArgs e)
        {
           // _09Settings.Properties.Settings.Default.Save();
        }
    }
}
