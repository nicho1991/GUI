using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace Lab24
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            char[] separatortors = {';'};
            string[] tokens;
            var str = "";


            InitializeComponent();
            ListBoxItem itm = new ListBoxItem();


          

            
            lists.Items.Add(itm);
            StreamReader sr = new StreamReader(@"deltagerliste.csv");
            sr.ReadLine();

            while ((str = sr.ReadLine()) != null)
            {
                //Console.WriteLine(str);
                //tokens = str.Split(separatortors, StringSplitOptions.RemoveEmptyEntries);
                tokens = str.Split(separatortors, StringSplitOptions.RemoveEmptyEntries);
                //full = full  + tokens[0] + "\t\t" + tokens[1] + "\t\t" + tokens [2] + "\t\t" + tokens [3] + "\n";
                var full = string.Format("{0:-12}{1,-32}{2,-12}{3,-32}", tokens[0], tokens[1], tokens[2],tokens[3]);
                //var full = tokens[0] + "\t\t" + tokens[1] + "\t\t" + tokens[2] + "\t\t" + tokens[3] + "\n";
                lists.Items.Add(full);
            }
 


        }
    }
}
