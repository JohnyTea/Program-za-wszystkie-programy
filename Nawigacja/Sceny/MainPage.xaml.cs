using Nawigacja.Sceny;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace Nawigacja
{


    public sealed partial class MainPage : Page
    {

        SettingsTheme settings = new SettingsTheme();
        public MainPage()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(StartPage));
        }
        


        private void Kolo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(KoloScena));
            //ContentFrame.Navigate(typeof(KoloScena));
        }

        private void Trojkat_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(TrojkatScena));
        }
        private void Kwadrat_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(KwadratScena));
        }
        private void Prostokat_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(ProstokatScena));
        }
        private void Statystyki_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Statystyki));
        }
        private void Profilaktyka_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Profilaktyka));
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

        private void PanelNawigacyjny_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                Frame.Navigate(typeof(Settings), settings);
            }
        }

        private void PanelNawigacyjny_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (ContentFrame.CanGoBack)
                ContentFrame.GoBack();
        }

        

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            ResourceLoader loader = new ResourceLoader();
            string kolo = loader.GetString("koło_str");
            string kwadrat = loader.GetString("kwadrat_str");
            string prostoka = loader.GetString("prostokat_str");
            string trojkat = loader.GetString("trojkat_str");

            string[] suggestions = new string[] { kolo, kwadrat, prostoka, trojkat};

            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                string text = sender.Text;
                if (sender.Text.Length > 1)
                {
                    sender.ItemsSource = suggestions;

                }
                else
                {
                    sender.ItemsSource = new string[] { loader.GetString("brakSugestii_str") };
                }
            }
            if (sender.Text == kolo)
            {
                ContentFrame.Navigate(typeof(KoloScena));
            }
            else if (sender.Text == kwadrat)
            {
                ContentFrame.Navigate(typeof(TrojkatScena));
            }
            else if (sender.Text == prostoka)
            {
                ContentFrame.Navigate(typeof(ProstokatScena));
            }
            else if (sender.Text == trojkat)
            {
                ContentFrame.Navigate(typeof(KwadratScena));
            }
        }

        
    }

}
