using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Nawigacja
{
    static class AppSettings
    {
        private static AppSettingsCurrent current = new AppSettingsCurrent();
        public static AppSettingsCurrent Current { get => current;}

    }

    class AppSettingsCurrent : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private  ApplicationTheme _theme = ApplicationTheme.Light;
        private  string _themeSTR = "Light";

        public  ApplicationTheme Theme
        {
            get => _theme;
            set
            {
                _theme = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Theme"));
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
                    PropertyChanged(this, new PropertyChangedEventArgs("ZmianaTheme"));
                }
                else if (_themeSTR == "Light")
                {
                    Theme = ApplicationTheme.Light;
                    _themeSTR = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("ZmianaTheme"));
                }

            }
        }

        public double BokKwadrat { 
            get => _bokKwadrat;
            set
            {
                _bokKwadrat = value;
                PropertyChanged(this, new PropertyChangedEventArgs("BokKwadrat"));
            }
        }
        public double BokAProstokat {
            get => _bokAProstokat;

            set
            {
                _bokAProstokat = value;
                PropertyChanged(this, new PropertyChangedEventArgs("BokAProstokat"));
            }
        }
        public double BokBProstokat {
            get => _bokBProstokat;
            set
            {
                _bokBProstokat = value;
                PropertyChanged(this, new PropertyChangedEventArgs("BokBProstokat"));
            }
        }
        public double PodstawaTrojkat 
        { get => _podstawaTrojkat;
            set
            {
                _podstawaTrojkat = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PodstawaTrojkat"));
            }
        }
        public double PromienKola { 
            get => _promienKola; 
            set 
            {
                _promienKola = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PromienKola"));
            }
        }

        double _bokKwadrat;
        double _bokAProstokat;
        double _bokBProstokat;
        double _podstawaTrojkat;
        double _promienKola;
    }
}
