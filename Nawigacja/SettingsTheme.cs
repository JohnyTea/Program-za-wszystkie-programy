using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nawigacja
{
    class SettingsTheme : INotifyPropertyChanged
    {
        public static string zmianaTheme;
        public SettingsTheme()
        {
            zmianaTheme = "Light";
        }

        public string ZmianaTheme
        {
            get => zmianaTheme;

            set
            {
                zmianaTheme = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ZmianaTheme"));

            }

        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
