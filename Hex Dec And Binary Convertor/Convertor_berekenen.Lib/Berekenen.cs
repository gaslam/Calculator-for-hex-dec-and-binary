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
            
            int modulo;
            nummer.Clear();

            while ((int) waarde >= 1)
            {
                modulo = (int)waarde % 16;
                waarde = (int) waarde / 16;
                hex = modulo.ToString("X");
                nummer.Insert(0, hex);
            }

            return nummer.ToString();
        }
    }
}
