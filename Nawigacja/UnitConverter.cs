using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Spi;
using Windows.UI.Composition;
using Windows.UI.Xaml;

namespace Nawigacja
{
    enum Unit
    {
        stopa,
        mila,
        funt,
        kilogram,
        metr,
        kilometr,
        length,
        weight
    }

    class UnitConverter
    {

        public static double ReadConvert(double dana, Unit rodzajDanej) //wartosc danej, aktualny sposób/jednostka zapisu danej
        {

            if (RegionInfo.CurrentRegion.IsMetric)
            {
                return dana;
            }
            else
            {
                switch (rodzajDanej)
                {
                    case Unit.kilogram:
                        return dana * 2.205; // na funty
                    case Unit.metr:
                        return dana * 3.281; // na stopy
                    case Unit.kilometr:
                        return dana * 0.621; // na mile
                }
            }
            throw new InvalidDataException("Błąd konwertowania danych");
        }

        public static double SaveConvert(double dana, Unit rodzajDanej) //wartosc danej, pozadany sposob zapisu danej
        {
            if (RegionInfo.CurrentRegion.IsMetric)
            {
                return dana;
            }
            else
            {
                switch (rodzajDanej)
                {
                    case Unit.kilogram:
                        return dana * 2.205; // na funty
                    case Unit.metr:
                        return dana * 3.281; // na stopy
                    case Unit.kilometr:
                        return dana * 0.621; // na mile
                }
            }
            throw new InvalidDataException("Błąd konwertowania danych");
        }

    }
}
