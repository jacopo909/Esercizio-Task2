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

namespace EsercizioTask
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Multipli(object sender, RoutedEventArgs e)
        {

            int numero = Convert.ToInt32(txtNumero.Text);
            prBar.Minimum = 0;
            prBar.Maximum = 100;
            StampaNumeri(numero);
            //Task<int> t1 = Task.Factory.StartNew(() => StampaNumeri(numero));
            //lb1.Content = $"{t1.Result} %";            
            //prBar.Value = t1.Result;
            
        }
        public async Task<int> StampaNumeri(int n)
        {
            
            int risultato = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 200000000; i++)
                {
                    if (i % n == 0)
                    {
                        risultato++;
                    }
                    if (i % 2000000 == 0)
                    {
                        prBar.Dispatcher.Invoke(() => prBar.Value++);
                    }


                }
                lb1.Dispatcher.Invoke(() => lb1.Content = risultato);
               //return risultato;
            });
            return risultato;
            
        }

        private void Click_Numero_Primo(object sender, RoutedEventArgs e)
        {
            int numero_primo = int.Parse(txtNumero.Text);
            bool isprimo = false;
            for (int i = 2; i < numero_primo; i++)
            {
                if (numero_primo % i == 0)
                {
                    isprimo = true;                   
                }
                
            }
            if (isprimo == true)
            {
                listbox1.Items.Clear();
                listbox1.Items.Add("è un numero primo");

            }
            else
            {
                listbox1.Items.Clear();
                listbox1.Items.Add("non è un numero primo");
            }
               
        }
    }
}
