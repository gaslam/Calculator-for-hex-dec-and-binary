﻿using System;
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
        StringBuilder nummer = new StringBuilder();

        #region hex and oct
        public string hexadecimal(decimal waarde)
        {
            voorComma = beforeComma(((int) waarde).ToString(), 4);
            if (waarde-(int)waarde > 0)
            {
                string[] split = waarde.ToString().Split(',');
                naComma = afterComma(split[1], 4);
            }
            return nummer.ToString();
        }

        public string octal(decimal waarde)
        {
            voorComma = beforeComma(((int)waarde).ToString(), 3);
            if (waarde - (int)waarde > 0)
            {
                string[] split = waarde.ToString().Split(',');
                naComma = afterComma(split[1], 3);
            }
            return nummer.ToString();
        }

        public string beforeComma(string waarde, int groupSize)
        {
            while (waarde.Length % groupSize != 0)
            {
                waarde = waarde.Insert(0, "0");
            }

            return Calculation1(waarde, groupSize);
        }

        public string afterComma(string value, int groupSize)
        {
            nummer.Insert(nummer.Length, ',');
            while (value.Length % groupSize != 0)
            {
                value = value.Insert(value.Length, "0");
            }

            return Calculation1(value, groupSize);
        }

        public string Calculation1(string value, int groupSize)
        {
            string split;
            while (value != "")
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
                
                nummer.Insert(nummer.Length, convert(split, 0));
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
            if (length == 3)
            {
                numberToAdd = numberToAdd.Except(new int[] {8}).ToArray();
            }
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
        #endregion

        #region Binary

        public string Decimaal(string value)
        {

            if (value.Contains('.') || value.Contains(','))
            {
                string[] split = value.Split(',');
                voorComma = beforeCommaBinary(split[0]);
                naComma = afterCommaBinary(split[1]);
            }
            else
            {
                voorComma = beforeCommaBinary(value);
            }

            return nummer.ToString();
        }

        private string beforeCommaBinary(string value)
        {
            int result = Convert.ToInt32(value, 2);
            nummer.Insert(0, result);
            return nummer.ToString();
        }

        private string afterCommaBinary(string value)
        {
            nummer.Insert(nummer.Length, ',');
            decimal result = 0;
            int twee = 2;
            decimal divide = 0;
            char[] split = value.ToCharArray();
            for (int i = 0; i < value.Length; i++)
            {
                if (split[i] == '1')
                {
                    divide = decimal.Divide(1, twee);
                    result = result + divide;
                }

                twee = twee* 2;
            }

            string[] split2 = result.ToString().Split(',');
            nummer.Insert(nummer.Length,split2[1]);
            return nummer.ToString();
        }

        #endregion
    }
}
