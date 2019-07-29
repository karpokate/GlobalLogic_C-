using System;
using System.Collections.Generic;
using System.Text;

namespace propis
{
    class Us: Country
    {
        private new readonly string[][] name = new string[][]
        {
            new string[] { "billion"},
            new string[] { "million"},
            new string[] { "thousand" },
            new string[] { "dollar", "dollars"},
            new string[] { "cent", "cents"}
        };
        private new readonly string[] number = new string[]
        {
            "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
            "eleven" , "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen",
            "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety",
            "one hundred","two hundred","three hundred", "four hundred", "five hundred",
            "six hundred", "seven hundred", "eight hundred", "nine hundred"
        };
        public override string ConvertToPropis(int[] value)
        {
            string sum = Conv(value[0], 0) + Conv(value[1], 1) + Conv(value[2], 2) + Conv(value[3], 3) + Conv(value[4], 4);
            if (sum == "")
                sum = "zero dollar zero cent";
            return sum;
        }
        public override string Conv(int value, int i)
        {
            if (value > 0)
            {
                string str = "";
                if (value / 100 > 0)
                {
                    str += " " + number[27 + value / 100];
                    value %= 100;
                }

                if (value > 19)
                {

                    str += " " + number[18 + value / 10];
                    value %= 10;
                }
                str += " " + number[value];
                str += " " + Declension(value, i);
                return str;
            }
            return "";
        }
        public override string Declension(int value, int i)
        {
            if (value != 1 && i > 2)
                return name[i][1];
            else
                return name[i][0];
        }
    }
}
