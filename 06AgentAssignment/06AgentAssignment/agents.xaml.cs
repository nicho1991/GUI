using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using I4GUI;

namespace _06AgentAssignment
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Agentss : Window
    {
        
        public Agentss()
        {
            InitializeComponent();

            DispatcherTimer timerobj = new DispatcherTimer(new TimeSpan(0,0,1),DispatcherPriority.Normal ,
                delegate { this.dateText.Content = DateTime.Now.ToString("U");},this.Dispatcher
                );
        }
    }
}
