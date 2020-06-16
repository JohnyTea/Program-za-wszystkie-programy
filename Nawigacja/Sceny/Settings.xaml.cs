using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
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
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
        }
        string theme;
        public string Theme { get => theme; set => theme = value; }
        private void DarkTheme_Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            AppSettings.Current.ThemeSTR = "Dark";
        }
        private void LightTheme_Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            AppSettings.Current.ThemeSTR = "Light";
        }

        private void JAngielski_Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ApplicationLanguages.PrimaryLanguageOverride = "en-US";
            CultureInfo.CurrentCulture.ClearCachedData();
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
            Frame.Navigate(this.GetType());
            Frame.GoBack();

        }

        private void JPolski_Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ApplicationLanguages.PrimaryLanguageOverride = "pl-PL";
            CultureInfo.CurrentCulture.ClearCachedData();
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
            Frame.Navigate(this.GetType());
            Frame.GoBack();
        }

        private void PanelNawigacyjny_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

    }
}
