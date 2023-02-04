using System;
using System.Collections;
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

namespace WPFszinkeveroV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            lbPirosValue.Content = sliPiros.Value;
            lbZoldValue.Content = sliZold.Value;
            lbKekValue.Content = sliKek.Value;
        }
        private void Szinkeveres()
        {
            byte red, green, blue;
            red = Convert.ToByte(sliPiros.Value);
            green = Convert.ToByte(sliZold.Value);
            blue = Convert.ToByte(sliKek.Value);
            Szinkeveres(red,green,blue);
        }

        private void Szinkeveres(byte r, byte g, byte b)
        {
            rctTegla.Fill = new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        private void piros_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Szinkeveres();

            lbPirosValue.Content = Convert.ToByte(sliPiros.Value);
        }

        private void zold_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Szinkeveres();
            lbZoldValue.Content = Convert.ToByte(sliZold.Value);
        }

        private void kek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Szinkeveres();
            lbKekValue.Content = Convert.ToByte(sliKek.Value);
        }


        private void rogzit_Click(object sender, RoutedEventArgs e)
        {


            byte red, green, blue;
            red = Convert.ToByte(sliPiros.Value);
            green = Convert.ToByte(sliZold.Value);
            blue = Convert.ToByte(sliKek.Value);
            string eredmeny = $"{red};{green};{blue}";
            bool IsInList = false;

            List<string?> feed = lbSzinek.Items.Cast<object>().Select(o => o.ToString()).ToList(); //stackoverflow 


            foreach (var item in feed)
            {
                if (item == eredmeny)
                {
                    MessageBox.Show("Már van ilyen elem felvéve!");
                    IsInList = true;
                    break;
                }
            }
            if (IsInList == false)
            {
                lbSzinek.Items.Add(eredmeny);
            }
        }

        private void torol_Click(object sender, RoutedEventArgs e)
        {
            if (lbSzinek.SelectedIndex >= 0)
            {
                lbSzinek.Items.RemoveAt(lbSzinek.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva egy elem se!");//felugro ablak ("nincs kiválasztva egy elem se")
            }
        }

        private void urit_Click(object sender, RoutedEventArgs e)
        {
            lbSzinek.Items.Clear();
        }

        private void lbSzinek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbSzinek.SelectedIndex >= 0)
            {
                string[] rgb = lbSzinek.SelectedItem.ToString().Split(';');
                byte r = Convert.ToByte(rgb[0]);
                byte g = Convert.ToByte(rgb[1]);
                byte b = Convert.ToByte(rgb[2]);


                lbPirosValue.Content = r;
                lbZoldValue.Content = g;
                lbKekValue.Content = b;

                sliPiros.Value = r;
                sliZold.Value = g;
                sliKek.Value = b;

                Szinkeveres(r, g, b);
            }
        }
    }
}
