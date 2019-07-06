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
        int hexvalue;
        int length;

        public string hexadecimal(string waarde)
        {
            string[] split = waarde.Split('.');
            voorComma = beforeComma(split[0]);
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
            StringBuilder nummer = new StringBuilder();
            while (value != "")
            {
                if (beforeComma == true)
                {
                    if (value.Length < groupSize)
                    {
                        split = value.Substring(0, value.Length);
                        length = value.Length;
                    }
                    else
                    {
                        split = value.Substring(0, groupSize);
                        length = groupSize;
                    }
                    voorComma = convert(split, 0);
                    
                    
                }
                nummer.Insert(nummer.Length, voorComma);
                if (value.Length == groupSize)
                {
                    value = string.Empty;
                }
                else if (value.Length > groupSize)
                {
                    value = value.Remove(0, length);
                }

            }

            return nummer.ToString();

        }

        public string convert(string value, int beginner)
        {
            int[] numberToAdd = new[] {8, 4, 2, 1};
            char[] split = value.ToCharArray();
            hexvalue = 0;
            for (int i = beginner; i < length; i++)
            {
                if (split[i] == '1')
                {
                     hexvalue += numberToAdd[i];   
                }
            }

            return hexvalue.ToString("X");
        }
    }
}
