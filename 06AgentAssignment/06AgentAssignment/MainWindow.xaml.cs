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
using I4GUI;

namespace _06AgentAssignment
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Agent _agent1 = new Agent("007","James Bond", "" , "Assasination" , "Kill the Queen");
        public Agent _agent2 = new Agent("1337", "perry", "", "cuddling", "make sweet love");
        public MainWindow()
        {
            InitializeComponent();
            agentlist.Items.Add(_agent1);
            agentlist.Items.Add(_agent2);
            //agentlist.Items.Add();

            DataContext = agentlist;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            agentlist.Items.Add(new Agent(IdBox.Text, CodeNameBox.Text, "", SpecialityBox.Text, AssignmentBox.Text));
        }
    }
}
