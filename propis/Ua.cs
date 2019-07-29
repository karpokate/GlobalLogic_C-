using System;
using System.Collections.Generic;
using System.Text;

namespace propis
{
    class Ua : Country
    {
        private new readonly string[][] name = new string[][]
        {
            new string[] { "мільярд", "мільярди" },
            new string[] { "мільйон", "мільйони","мільйонів" },
            new string[] { "тисяча", "тисячі", "тисяч" },
            new string[] { "гривня", "гривні", "гривень" },
            new string[] { "копійка", "копійки","копійок" }
        };
        private new readonly string[] number = new string[]
        {
            "", "один", "два", "три", "чотири", "п'ять", "шість", "сім", "вісім", "дев'ять", "десять",
            "одинадцять", "дванадцять", "тринадцять", "чотирнадцять", "п'ятнадцять", "шістнадцять", "сімнадцять", "вісімнадцять", "дев'ятнадцять",
            "двадцять", "тридцять", "сорок", "п'ятдесят", "шістдесят", "сімдесят", "вісімдесят", "дев'яносто",
            "сто", "двісті", "триста", "чотириста", "п'ятсот", "шістсот", "сімсот", "вісімсот", "дев'ятсот"
        };
        public override string ConvertToPropis(int[] value)
        {
            string sum = Conv(value[0], 0) + Conv(value[1], 1) + Conv(value[2], 2) + Conv(value[3], 3) + Conv(value[4], 4);
            if (sum == "")
                sum = "нуль гривень нуль копійок";
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
                if (i > 1 && value == 1)
                    str += " одна";
                else
                    if (i > 1 && value == 2)
                    str += " дві";
                else str += " " + number[value];
                str += " " + Declension(value, i);
                return str;
            }
            return "";
        }
        public override string Declension(int value, int i)
        {
            if (value == 1)
                return name[i][0];
            else
                if (value < 5)
                    return name[i][1];
                else
                    return name[i][2];
        }
    }
}
