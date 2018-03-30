using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;

namespace BabyName
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<BabyNameClass> babyList = new List<BabyNameClass>();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += onLoad;

        }

        void onLoad(object sender, RoutedEventArgs e)
        {
            
            //load file
            foreach (var xy in File.ReadAllLines("babynames.txt"))
            {
                string x = xy;
                string ny = Regex.Replace(x, "a", "b");
                babyList.Add(new BabyNameClass(ny));
   
            }

            //setup Decade list 00 - 90
            for (int i = 0; i < 10; i++)
            {
                Decades.Items.Add(new MenuItem().Header = "19" + i + "0");
            }
            // 2000

            Decades.Items.Add(new MenuItem().Header = "2000");

            e.Handled = true;
        }

        private void Decades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstDecadeTopNames.Items.Clear();
            int theYear = Int32.Parse(Decades.SelectedItem.ToString());
            IEnumerable<BabyNameClass> babyenum = babyList.OrderByDescending(babyNameClass => babyNameClass.Rank(theYear));
            
            //list the babies!
            foreach (var VARIABLE in babyenum)
            {
                lstDecadeTopNames.Items.Add("Name: "+VARIABLE.Name + " \t\tRank: " + VARIABLE.Rank(theYear));
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //get the name
            string name = searchTextBox.Text;

            //got the baby
            var baby = babyList.Find(o => o.Name.Contains(name));
            int trend;
            try
            {
                // Returns the trend (i.e. average change) over the last 20 years (1980..2000)
                //   of the century for this  name; this is a positive value if the name is
                //   becoming more popular, a negative value if the name is becoming less popular,
                //   and zero if the name didn't change in popularity or the change isn't
                //   consistent (increase then decrease, or vice versa).
                avgRankingBox.Text = baby.AverageRank().ToString();
                trend = baby.Trend();
                if (trend == 0)
                    trendbox.Text = "no Trend";
                else if (trend > 0)
                    trendbox.Text = "trending";
                else
                    trendbox.Text = "not Trending";

                for (int i = 1900; i < 2010; i += 10)
                {
                    YearRankBox.Items.Add(i + " " + baby.Rank(i));
                }
            }

            catch (Exception exception)
            {
                avgRankingBox.Text = "no names like that in database";
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            App.Current.Shutdown();
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            theWindow.FontSize = 10;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            theWindow.FontSize = 15;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            theWindow.FontSize = 20;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            theWindow.FontSize = 25;
        }
    }

}
