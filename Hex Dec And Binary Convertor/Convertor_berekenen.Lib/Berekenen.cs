using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convertor_berekenen.Lib
{
    public class Berekenen
    {
        StringBuilder nummer = new StringBuilder();
        string hex;

        public string Nummer(decimal waarde)
        {
            decimal doubleWaarde = waarde;
            int modulo;
            nummer.Clear();

            while ((int) doubleWaarde > 1)
            {
                modulo = (int)doubleWaarde % 16;
                doubleWaarde = (int) doubleWaarde / 16;
                hex = modulo.ToString("X");
                nummer.Insert(0, hex);
            }

            return nummer.ToString();
        }
    }
}
