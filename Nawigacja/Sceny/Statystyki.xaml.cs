using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
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

namespace Nawigacja
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class Statystyki : Page
    {
        public Statystyki()
        {
            this.InitializeComponent();
            ResourceLoader loader = new ResourceLoader();
            int zmienna = 5, zmienna2 = 10;
            string zdanie = String.Format(loader.GetString("zdanie_str"), zmienna, zmienna2);
            Zdanie_TextBlock.Text = zdanie;

        }
        
        private void Zapisz_Button_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void DataTimePicker_DataChanger(object sender, DatePickerValueChangedEventArgs e)
        {
            AppSettings.Current.DataUr = DataUrodzenia_DateTimePicker.Date;
        }
    }
}
