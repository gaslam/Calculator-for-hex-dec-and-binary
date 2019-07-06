using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                MultiplyAfterComma(waarde - (int) waarde, 16, true);
            }
            return nummer.ToString();

        }

        public string octaalNummer(decimal waarde)
        {
            nummer.Clear();
            DivideBeforeComma(waarde, 8);
            if (waarde - (int)waarde > 0)
            {
                MultiplyAfterComma(waarde - (int)waarde, 8, true);
            }
            return nummer.ToString();
        }

        public string binairNummer(decimal waarde)
        {
            nummer.Clear();
            DivideBeforeComma(waarde, 2);
            if (waarde - (int)waarde > 0)
            {
                MultiplyAfterComma(waarde - (int)waarde, 2, true);
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

        public string MultiplyAfterComma(decimal waarde, decimal vermenigvuldiger, bool exception)
        {
            nummer.Insert(nummer.Length, ",");
            decimal vermenigvuldiging;
            int noComma;

            for (int i = 0; i < 4; i++)
            {
                vermenigvuldiging = waarde * vermenigvuldiger;
                noComma = (int) vermenigvuldiging;
                waarde = vermenigvuldiging - ((int)vermenigvuldiging);
                hex = noComma.ToString("X");
                nummer.Insert(nummer.Length, hex);

                if (waarde == 0 && exception == true)
                {
                    break;
                }            
            }
            return nummer.ToString();
        }
    }
}
