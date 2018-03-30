using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CalcPiAlgoritm;

namespace Lab12_1
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public delegate void BackgroundThread();
      public MainWindow()
      {
         InitializeComponent();
      }

      private void miFileExit_Click(object sender, RoutedEventArgs e)
      {
         Close();
      }

      private void btnCalculate_Click(object sender, RoutedEventArgs e)
      {
          int digits = int.Parse(tbxDigits.Text);
          Thread t = new Thread(new ParameterizedThreadStart(RunOnWorkerThread));
          t.Start(digits);
                    
      }

       void RunOnWorkerThread(object digits)
       {
           // Update statusbar
           Dispatcher.BeginInvoke(new Action(() =>
           {
               sbiStatus.Content = "Calculating...";
           }));

            // Convert control's decimal Value to an integer
            CalcPi((int)digits);

           Dispatcher.BeginInvoke(new Action(() =>
           {
               // Update statusbar
               sbiStatus.Content = "Ready";
           }));

        }
      void CalcPi(int digits)
      {
         StringBuilder pi = new StringBuilder("3", digits + 2);

            // Show progress

          Dispatcher.BeginInvoke(new Action(() =>
          {
              ShowProgress(pi.ToString(), digits, 0);
          }));

         if (digits > 0)
         {
            pi.Append(".");

            for (int i = 0; i < digits; i += 9)
            {
               int nineDigits = NineDigitsOfPi.StartingAt(i + 1);
               int digitCount = Math.Min(digits - i, 9);
               string ds = string.Format("{0:D9}", nineDigits);
               pi.Append(ds.Substring(0, digitCount));

                    // Show progress
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    ShowProgress(pi.ToString(), digits, i + digitCount);
                }));

            }
         }
      }

      void ShowProgress(string pi, int totalDigits, int digitsSoFar) {
      // Display progress in UI
         tblkResults.Text = pi;
         progressBar.Maximum = totalDigits;
         progressBar.Value = digitsSoFar;
         progressBar.Visibility = Visibility.Visible;

      if( digitsSoFar == totalDigits ) {
        // Reset UI
        sbiStatus.Content = "Ready";
        progressBar.Visibility = Visibility.Hidden;
      }
    }

   }
}
