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
            voorComma = Calculation(Comma[0].ToString());

            if (Comma.Length > 1 && Comma[1].ToString() != "")
            {
                Nummer.Insert(Nummer.Length, ',');
                naComma = Calculation(Comma[1].ToString());
            }
                return Zero(Nummer.ToString(), true);


        }

        public string decimaal(string ingave)
        {
            Comma = split(ingave);

            voorComma = Convert.ToInt32(Comma[0], 16).ToString();
            Nummer.Insert(0, voorComma);
            if (Comma.Length > 1 && Comma[1].ToString() != "")
            {
                naComma = afterComma(Comma[1] , 16);
            }
            return Nummer.ToString();
        }

        public string Octaal(string ingave)
        {
            Comma = split(ingave);
            voorComma = octaalBeforeComma(Comma[0]);

            if (Comma.Length > 1 && Comma[1].ToString() != "")
            {
                Nummer.Insert(Nummer.Length, ',');
                naComma = Calculation(Comma[1].ToString());
            }

            return Nummer.ToString();
        }

        public string octaalBeforeComma(string value)
        {
            double result = Convert.ToInt32(value, 16);
            int modulo;
            while (result >= 1)
            {
                modulo = (int)result % 8;
                Nummer.Insert(0, modulo);
                result = (int)result / 8;
            }
            return Nummer.ToString();
        }

        public string afterComma(string value, int multiplier)
        {
            decimal result = 0;
            char[] split = value.ToCharArray();

            foreach (char character in split)
            {
                int convert = Convert.ToInt32(character.ToString(), multiplier);
                decimal divide = decimal.Divide(convert, multiplier);
                result = result + divide;

                multiplier = multiplier * 2;
            }

            string[] split2 = result.ToString().Split(',', '.');
            Nummer.Insert(Nummer.Length, ',' + split2[1]);
            return Nummer.ToString();
        }

        public string Calculation(string waarde)
        {
            Char[] split = waarde.ToCharArray();
            foreach (char character in split)
            {
                decvalue = Convert.ToInt32(character.ToString(), 16);
                Console.WriteLine("result:" + decvalue);
                string result = Calculation2(decvalue.ToString());
                Nummer.Insert(Nummer.Length, result);
            }

            return Nummer.ToString();
        }

        public string Calculation2(string waarde)
        {
            int[] powers = new[] { 8, 4, 2, 1 };
            StringBuilder value = new StringBuilder();
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

            return value.ToString();
        }

        public string Calculation3(decimal BeforeComma)
        {
            while (BeforeComma > 0)
            {
                int modulo = (int) BeforeComma % 8;
                BeforeComma = (int) BeforeComma / 8;
                Console.WriteLine(modulo);
            }

            return Nummer.ToString();
        }

        public string Zero(string waarde, bool firstOrLast)
        {
            char[] split = waarde.ToCharArray();
            while (split.First() == '0' && firstOrLast == true)
            {
                if (split[0] == '0' && firstOrLast == true)
                {
                    split = split.Skip(1).ToArray();
                }

            }

            while (split.Last() == '0' && firstOrLast == false)
            {
                if (split.Last() == '0' && firstOrLast == false)
                {
                    split = split.Reverse().Skip(1).Reverse().ToArray();
                }
            }

            string result = new string(split);

            return result;
        }

        public string[] split(string waarde)
        {
            string[] split2 = waarde.Split('.', ',');

            return split2;
        }
    }
}
