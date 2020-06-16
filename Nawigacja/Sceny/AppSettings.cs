using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Nawigacja
{
    
    class AppSettings : INotifyPropertyChanged
    {

        public static AppSettings Current { get; }  = new AppSettings();

        public event PropertyChangedEventHandler PropertyChanged;

        private  ApplicationTheme _theme = ApplicationTheme.Light;
        private  string _themeSTR = "Light";
        private double _bokKwadrat;
        private double _bokAProstokat;
        private double _bokBProstokat;
        private double _podstawaTrojkat;
        private double _promienKola;
        private string _imie;
        private string _nazwisko;
        private DateTimeOffset _dataUr;
        private double _masaCiala;
        private double _wzrost;
        private double _zarobki;

        public  ApplicationTheme Theme
        {
            get => _theme;
            set
            {
                _theme = value;
                RaisePropertyChanged("Theme");
            }
        }

        public  string ThemeSTR
        {
            get => _themeSTR;
            set
            {
                
                if (_themeSTR == "Dark")
                {
                    Theme = ApplicationTheme.Dark;
                    _themeSTR = value;
                    RaisePropertyChanged("ZmianaTheme");
                }
                else if (_themeSTR == "Light")
                {
                    Theme = ApplicationTheme.Light;
                    _themeSTR = value;
                    RaisePropertyChanged("ZmianaTheme");
                }

            }
        }

        public double BokKwadrat { 
            get => _bokKwadrat;
            set
            {
                _bokKwadrat = value;
                RaisePropertyChanged("BokKwadrat");
            }
        }
        public double BokAProstokat {
            get => _bokAProstokat;

            set
            {
                _bokAProstokat = value;
                RaisePropertyChanged("BokAProstokat");
            }
        }
        public double BokBProstokat {
            get => _bokBProstokat;
            set
            {
                _bokBProstokat = value;
                RaisePropertyChanged("BokBProstokat");
            }
        }
        public double PodstawaTrojkat 
        { get => _podstawaTrojkat;
            set
            {
                _podstawaTrojkat = value;
                RaisePropertyChanged("PodstawaTrojkat");
            }
        }
        public double PromienKola { 
            get => _promienKola; 
            set 
            {
                _promienKola = value;
                RaisePropertyChanged("PromienKola");
            }
        }

        public string Imie
        {
            get => _imie;
            set
            {
                _imie = value;
                RaisePropertyChanged("Imie");

            }
        }
        public string Nazwisko
        {
            get => _nazwisko; 
            set
            {
                _nazwisko = value;
                RaisePropertyChanged("Nazwisko");

            }
        }
        public DateTimeOffset DataUr
        {
            get => _dataUr; 
            set
            {
                _dataUr = value;
                RaisePropertyChanged("DataUr");

            }
        }
        public double MasaCiala
        {
            get
            {
                return UnitConverter.ReadConvert(_masaCiala, Unit.kilogram);
            }
            set
            {
                _masaCiala = UnitConverter.SaveConvert(value, Unit.kilogram);
                RaisePropertyChanged("MasaCiala");

            }
        }
        public double Wzrost
        {
            get
            {
                return UnitConverter.ReadConvert(_wzrost, Unit.metr);
            }
            set
            {
                _wzrost = UnitConverter.SaveConvert(value, Unit.metr);
                RaisePropertyChanged("Wzrost");

            }
        }
        public double Zarobki
        {
            get => _zarobki; 
            set
            {
                _zarobki = value;
                RaisePropertyChanged("Zarobki");
            }
        }

        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
