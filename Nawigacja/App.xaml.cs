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

namespace Nawigacja
{
    /// <summary>
    /// Zapewnia zachowanie specyficzne dla aplikacji, aby uzupełnić domyślną klasę aplikacji.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Inicjuje pojedynczy obiekt aplikacji. Jest to pierwszy wiersz napisanego kodu
        /// wykonywanego i jest logicznym odpowiednikiem metod main() lub WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            this.Resuming += App_Resuming;
        }

        /// <summary>
        /// Wywoływane, gdy aplikacja jest uruchamiana normalnie przez użytkownika końcowego. Inne punkty wejścia
        /// będą używane, kiedy aplikacja zostanie uruchomiona w celu otworzenia określonego pliku.
        /// </summary>
        /// <param name="e">Szczegóły dotyczące żądania uruchomienia i procesu.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Nie powtarzaj inicjowania aplikacji, gdy w oknie znajduje się już zawartość,
            // upewnij się tylko, że okno jest aktywne
            if (rootFrame == null)
            {
                // Utwórz ramkę, która będzie pełnić funkcję kontekstu nawigacji, i przejdź do pierwszej strony
                rootFrame = new Frame();
                rootFrame.NavigationFailed += OnNavigationFailed;
                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Załaduj stan z wstrzymanej wcześniej aplikacji
                    await ReadStateAsync();
                    var terminateDate = DateTime.Now;
                    if (_store.ContainsKey("timestamp"))
                    {
                        terminateDate = (DateTime)_store["timestamp"];
                    }
                    if (_store.ContainsKey("theme"))
                    {
                        AppSettings.Current.ThemeSTR = (string)_store["theme"];
                    }
                    if (_store.ContainsKey("bokKwadratu"))
                    {
                        AppSettings.Current.BokKwadrat = (double)_store["bokKwadratu"];
                    }
                    if (_store.ContainsKey("bokAProstokata"))
                    {
                        AppSettings.Current.BokAProstokat = (double)_store["bokAProstokata"];
                    }
                    if (_store.ContainsKey("bokBProstokata"))
                    {
                        AppSettings.Current.BokBProstokat = (double)_store["bokBProstokata"];
                    }
                    if (_store.ContainsKey("podstawaTrojkata"))
                    {
                        AppSettings.Current.PodstawaTrojkat = (double)_store["podstawaTrojkata"];
                    }
                    if (_store.ContainsKey("promienKola"))
                    {
                        AppSettings.Current.PromienKola = (double)_store["promienKola"];
                    }
                    if (_store.ContainsKey("frame"))
                    {
                        rootFrame.SetNavigationState((string)_store["frame"]);
                    }


                }

                // Umieść ramkę w bieżącym oknie
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // Kiedy stos nawigacji nie jest przywrócony, przejdź do pierwszej strony,
                    // konfigurując nową stronę przez przekazanie wymaganych informacji jako
                    // parametr
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Upewnij się, ze bieżące okno jest aktywne
                Window.Current.Activate();
            }
        }

        

        /// <summary>
        /// Wywoływane, gdy nawigacja do konkretnej strony nie powiedzie się
        /// </summary>
        /// <param name="sender">Ramka, do której nawigacja nie powiodła się</param>
        /// <param name="e">Szczegóły dotyczące niepowodzenia nawigacji</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Wywoływane, gdy wykonanie aplikacji jest wstrzymywane. Stan aplikacji jest zapisywany
        /// bez wiedzy o tym, czy aplikacja zostanie zakończona, czy wznowiona z niezmienioną zawartością
        /// pamięci.
        /// </summary>
        /// <param name="sender">Źródło żądania wstrzymania.</param>
        /// <param name="e">Szczegóły żądania wstrzymania.</param>
        /// 


        private Dictionary<string, object> _store;
        private readonly string _saveFileName = "store.xml";
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            
            var deferral = e.SuspendingOperation.GetDeferral();
            _store = new Dictionary<string, object>();
            //_store.Add("theme", AppSettings.Current.ThemeSTR);
            _store.Add("promienKola", AppSettings.Current.PromienKola);
            _store.Add("bokKwadratu", AppSettings.Current.BokKwadrat);
            _store.Add("bokAProstokata", AppSettings.Current.BokAProstokat);
            _store.Add("bokBProstokata", AppSettings.Current.BokBProstokat);
            _store.Add("podstawaTrojkata", AppSettings.Current.PodstawaTrojkat);

            Frame currentFrame = Window.Current.Content as Frame;

            _store.Add("frame", currentFrame.GetNavigationState());

            await SaveStateAsync();
            //TODO: Save application state and stop any background activity
            //Here you can use  await SuspensionManager.SaveAsync();
            //To read more about saving state please refer to below MSDN Blog article:
            //https://blogs.windows.com/buildingapps/2016/04/28/the-lifecycle-of-a-uwp-app/#RqKAKkevsAPIvBUT.97
            deferral.Complete();
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

        private void App_Resuming(object sender, object e)
        {
            //Do some operation connected with app resuming for instance refresh data
            //throw new NotImplementedException();
        }
    }
}
