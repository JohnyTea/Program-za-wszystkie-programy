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
    public sealed partial class ProstokatScena : Page
    {
        public ProstokatScena()
        {
            this.InitializeComponent();
            Oblicz(AppSettings.Current.BokAProstokat, AppSettings.Current.BokBProstokat);
        }

        private void Oblicz_Button_Click(object sender, RoutedEventArgs e)
        {
            double bokA;
            bokA = double.Parse(DlugoscBokuATextBlock.Text);
            double bokB;
            bokB = double.Parse(DlugoscBokuBTextBlock.Text);
            Oblicz(bokA, bokB);
        }

        private void Oblicz(double bokA, double bokB)
        {
            double obwod = bokA * 2 + bokB * 2;
            double pole = bokA * bokB;
            obwodWynik_TB.Text = obwod.ToString();
            poleWynik_TB.Text = pole.ToString();
        }

        private void Powrot_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }


    }
}
