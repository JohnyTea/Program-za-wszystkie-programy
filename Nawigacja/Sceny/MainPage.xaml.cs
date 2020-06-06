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
            Application.Current.Suspending += new SuspendingEventHandler(App_Suspending);
        }
        private Dictionary<string, object> _store;
        private readonly string _saveFileName = "store.xml";
        async void App_Suspending(
        Object sender,
        Windows.ApplicationModel.SuspendingEventArgs e)
        {
            // TODO: This is the time to save app data in case the process is terminated.
            _store = new Dictionary<string, object>();
            //_store.Add("theme", AppSettings.Current.ThemeSTR);
            _store.Add("promienKola", AppSettings.Current.PromienKola);
            _store.Add("bokKwadratu", AppSettings.Current.BokKwadrat);
            _store.Add("bokAProstokata", AppSettings.Current.BokAProstokat);
            _store.Add("bokBProstokata", AppSettings.Current.BokBProstokat);
            _store.Add("podstawaTrojkata", AppSettings.Current.PodstawaTrojkat);

            Frame currentFrame = Window.Current.Content as Frame;
            //dokumentacja ze tak sie to robi https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.frame.getnavigationstate?view=winrt-19041
            _store.Add("frame", currentFrame.GetNavigationState());

            await SaveStateAsync();
        }

        private async Task SaveStateAsync()
        {
            var ms = new MemoryStream();
            var serializer = new DataContractSerializer(typeof(Dictionary<string, object>));
            serializer.WriteObject(ms, _store);

            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(_saveFileName, CreationCollisionOption.ReplaceExisting);

            using (var fs = await file.OpenStreamForWriteAsync())
            {
                //because we have written to the stream, set the position back to start
                ms.Seek(0, SeekOrigin.Begin);
                await ms.CopyToAsync(fs);
                await fs.FlushAsync();
            }
        }

        private async Task ReadStateAsync()
        {
            var file = await ApplicationData.Current.LocalFolder.GetFileAsync(_saveFileName);
            if (file == null) return;

            using (IInputStream stream = await file.OpenSequentialReadAsync())
            {
                var serializer = new DataContractSerializer(typeof(Dictionary<string, object>));
                _store = (Dictionary<string, object>)serializer.ReadObject(stream.AsStreamForRead());
            }
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
                ContentFrame.Navigate(typeof(Settings), settings);
            }
        }

        private void PanelNawigacyjny_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (ContentFrame.CanGoBack)
                ContentFrame.GoBack();
        }

        private string[] suggestions = new string[] { "Koło", "Kwadrat", "Prostokat", "Trojkat", "Statystyki", "Profilaktyka" };
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
                case "Koło":

                    ContentFrame.Navigate(typeof(KoloScena));
                    break;
                case "Trojkat":

                    ContentFrame.Navigate(typeof(TrojkatScena));
                    break;
                case "Prostokat":

                    ContentFrame.Navigate(typeof(ProstokatScena));
                    break;
                case "Kwadrat":

                    ContentFrame.Navigate(typeof(KwadratScena));
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
