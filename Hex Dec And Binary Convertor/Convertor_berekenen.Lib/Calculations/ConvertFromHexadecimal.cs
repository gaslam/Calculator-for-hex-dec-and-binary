using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convertor_berekenen.Lib.Calculations
{
    public class ConvertFromHexadecimal
    {
        StringBuilder Nummer = new StringBuilder();
        public string voorComma { get; set; }
        public string naComma { get; set; }
        public string[] Comma { get; set; }
        int decvalue;
        int length;

        public string binary(string ingave)
        {
            Comma = split(ingave);
            voorComma = beforeComma(Comma[0].ToString());
            return Nummer.ToString();
        }

        public string beforeComma(string waarde)
        {
            Char[] split = waarde.ToCharArray();
            foreach (char character in split)
            {
                decvalue = Convert.ToInt32(character.ToString(), 16);
                Console.WriteLine("result:" + decvalue);
                string result = Calculation(decvalue.ToString());
                Nummer.Insert(Nummer.Length, result);
            }

            return Nummer.ToString();
        }

        public string Calculation(string waarde)
        {
            int[] powers = new[] { 8, 4, 2, 1 };
            StringBuilder value =  new StringBuilder();
            int parsedValue = int.Parse(waarde);
            for (int i = 0; i < 4; i++)
            {
                if (powers[i] <= parsedValue)
                {
                    value.Insert(value.Length, "1");
                    parsedValue -= powers[i];
                }
                else
                {
                    value.Insert(value.Length, "0");
                }
            }

            string zero = Zero(value.ToString());
            return zero;
        }

        public string Zero(string waarde)
        {
            char[] split = waarde.ToCharArray();
            while (split[0] == '0')
            {
                if (split[0] == '0')
                {
                    split = split.Skip(1).ToArray();
                }
            }
            string result = new string(split);

            return result;
        }

        public string[] split(string waarde)
        {
            string[] split2 = waarde.Split('.' , ',');

            return split2;
        }
    }
}
