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
    public sealed partial class StartPage : Page
    {
        public StartPage()
        {
            this.InitializeComponent();
        }

        private void Trojkat_Img_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(TrojkatScena));
        }
        private void Kolo_Img_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(KoloScena));
        }
        private void Kwadrat_Img_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(KwadratScena));
        }
        private void Prostokat_Img_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProstokatScena));
        }
    }
}
