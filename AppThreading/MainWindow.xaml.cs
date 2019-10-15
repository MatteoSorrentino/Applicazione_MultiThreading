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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppThreading
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

        private void Btn_Task_Click(object sender, RoutedEventArgs e)
        {
            //DoWork();
            lbl_Risultato.Content = "";
            Task.Factory.StartNew(DoWork);
        }

        private void DoWork()
        {
            for (int i = 0; i <= 1000; i++)
            {
                for (int j = 0; j <= 1000; j++)
                {

                }
            }

            //AggiornaInteraccia();
            Dispatcher.Invoke(AggiornaInteraccia);
        }

        private void AggiornaInteraccia()
        {
            lbl_Risultato.Content = "Finito";
        }


        private void Btn_Count_Click(object sender, RoutedEventArgs e)
        {
            //DoCount();
            Task.Factory.StartNew(DoCount);
        }

        private void DoCount()
        {
            for (int i = 0; i <= 10000; i++)
            {
                for (int j = 0; j <= 10000; j++)
                {
                    Dispatcher.Invoke(() => AggiornaInteraccia(j));
                    Thread.Sleep(1000);
                }
            }
        }

        private void AggiornaInteraccia(int j)
        {
            lbl_Conteggio.Content = j.ToString();
        }
    }
}
