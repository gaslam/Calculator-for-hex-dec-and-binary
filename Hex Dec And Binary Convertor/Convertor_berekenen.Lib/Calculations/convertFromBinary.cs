using System;
using System.Text;

namespace Convertor_berekenen.Lib.Calculations
{
    public class convertFromBinary
    {
        public int voorComma { get; set; }
        public int naComma { get; set; }
        StringBuilder nummer = new StringBuilder();

        public string hexadecimal(decimal waarde)
        {
            voorComma = beforeComma((Convert.ToString((int) waarde)));
            return nummer.ToString();
        }

        public int beforeComma(string waarde)
        {
            while (waarde.Length % 4 != 0)
            {
                waarde = waarde.Insert(0, "0");
            }
            return int.Parse(waarde);
        }
    }
}
