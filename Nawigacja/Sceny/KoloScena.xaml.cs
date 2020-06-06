using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace Nawigacja.Sceny
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class KoloScena : Page
    {
        public KoloScena()
        {
            this.InitializeComponent();
            if (AppSettings.Current.PromienKola != 0)
                Promien_TextBlock.Text = AppSettings.Current.PromienKola.ToString();
        }

        private void Oblicz_Button_Click(object sender, RoutedEventArgs e)
        {
            double promien = double.Parse(Promien_TextBlock.Text);

            double obwod = 2 * Math.PI * promien;
            double pole = Math.PI * Math.Pow(promien, 2);
            obwodWynik_TB.Text = obwod.ToString();
            poleWynik_TB.Text = pole.ToString();
            AppSettings.Current.PromienKola = promien;
        }

        private void Powrot_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
