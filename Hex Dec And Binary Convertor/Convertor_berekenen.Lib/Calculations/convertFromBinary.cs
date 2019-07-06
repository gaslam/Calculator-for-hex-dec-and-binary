using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Convertor_berekenen.Lib.Calculations
{
    public class convertFromBinary
    {
        public string voorComma { get; set; }
        public string naComma { get; set; }
        string convert2;

        StringBuilder nummer = new StringBuilder();

        public string hexadecimal(decimal waarde)
        {
            voorComma = beforeComma((Convert.ToString((int) waarde)));
            return voorComma.ToString();
        }

        public string beforeComma(string waarde)
        {
            while (waarde.Length % 4 != 0)
            {
                waarde = waarde.Insert(0, "0");
            }

            return Calculation(waarde, true, 4);
        }

        public string Calculation(string value, bool beforeComma, int groupSize)
        {
            string split;
            while (value != "")
            {
                if (beforeComma == true)
                {
                    split = value.Substring(0, groupSize);
                    voorComma = convert(value, 0);
                    value = value.Remove(0, value.Length);
                    
                }
            }

            return voorComma;

        }

        public string convert(string value, int beginner)
        {
            int[] numberToAdd = new[] {8, 4, 2, 1};
            char[] split = value.ToCharArray();
            for (int i = beginner; i < split.Length; i++)
            {
                if (split[i] == '1')
                {
                    int multiplier = int.Parse(split[i].ToString());
                    string hexvalue = (multiplier * numberToAdd[i]).ToString("X");
                    convert2 += hexvalue;
                }
            }

            return convert2.ToString();
        }
    }
}
