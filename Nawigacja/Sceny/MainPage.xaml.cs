using Nawigacja.Sceny;
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

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace Nawigacja
{

    
        public sealed partial class MainPage : Page
        {

        SettingsTheme settings=new SettingsTheme();
        public MainPage()
            {
                this.InitializeComponent();
            }

        private void Pierwsze_zachorowania_polska_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(PierwszeZachorowania));
        }

        private void LiczbaZachorowan_polska_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(LiczbaZachorowan));
        }
        private void Pierwsze_zachorowania_swiat_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(PierwszeZachorowaniaSwiat));
        }
        private void LiczbaZachorowan_Swiat_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(LiczbaZachorowanSwiat));
        }
        private void Statystyki_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Statystyki));
        }
        private void Profilaktyka_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Profilaktyka));
        }

         

        private void PanelNawigacyjny_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
            {
                if (args.IsSettingsSelected)
                {
                    ContentFrame.Navigate(typeof(Settings), settings);
                }
            }

            private void PanelNawigacyjny_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
            {
                if (ContentFrame.CanGoBack)
                    ContentFrame.GoBack();
            }

        private string[] suggestions = new string[] { "Liczba zachorowań w polsce", "Liczba zachorowań na świecie", "Pierwsze zachorowania w Polsce", "Pierwsze zachorowania na świecie", "Statystyki", "Profilaktyka" };
        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
            {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                string text = sender.Text;
                if (sender.Text.Length > 1)
                {
                    sender.ItemsSource = suggestions;

                }
                else
                {
                    sender.ItemsSource = new string[] { "No suggestions..." };
                }
            }
            switch (sender.Text)
            {
                case "Liczba zachorowań w polsce":

                    ContentFrame.Navigate(typeof(LiczbaZachorowan));
                    break;
                case "Liczba zachorowań na świecie":

                    ContentFrame.Navigate(typeof(LiczbaZachorowanSwiat));
                    break;
                case "Pierwsze zachorowania w Polsce":

                    ContentFrame.Navigate(typeof(PierwszeZachorowania));
                    break;
                case "Pierwsze zachorowania na świecie":

                    ContentFrame.Navigate(typeof(PierwszeZachorowaniaSwiat));
                    break;
                case "Statystyki":

                    ContentFrame.Navigate(typeof(Statystyki));
                    break;
                case "Profilaktyka":

                    ContentFrame.Navigate(typeof(Profilaktyka));
                    break;
            }
        }
           
        }
    
}
