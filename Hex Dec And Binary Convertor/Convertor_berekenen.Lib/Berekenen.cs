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

        public string hexNummer(decimal waarde)
        {
            nummer.Clear();
            DivideBeforeComma(waarde, 16);
            if (waarde - (int) waarde > 0)
            {
                Console.WriteLine("test");
            }
            return nummer.ToString();

        }

        public string DivideBeforeComma(decimal waarde, int deler)
        {
            int modulo;
            while ((int)waarde >= 1)
            {
                modulo = (int)waarde % deler;
                waarde = (int)waarde / deler;
                hex = modulo.ToString("X");
                nummer.Insert(0, hex);
            }

            return nummer.ToString();
        }
    }
}
