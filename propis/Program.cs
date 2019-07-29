using System;

namespace propis
{
    class Program
    {
        static int[] ConvToInt(string[] str)
        {
            int[] money = { 0, 0, 0, 0, 0 };
            if(str[0].Length>9 && Convert.ToInt64(str[0])>Int32.MaxValue)
            {
                Console.WriteLine("Incorrect sum, max " + Int32.MaxValue);
                return money;
            }
            money[0] = Convert.ToInt32(str[0]);
            if (str.Length > 1 )
                money[4] = int.Parse((str[1]+"0").Substring(0, 2));
            for (int i = 3; i > 0; i--)
            {
                money[i] = money[0] % 1000;
                money[0] /= 1000;
            }
            return money;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            Console.Write("Write your data:\n" +
                "Country(US or UA): ");
            string country = Console.ReadLine().ToLower().Trim();
            Console.Write("Sum (0 to 2147483647): ");
            string[] sum = Console.ReadLine().Split('.', ',');
            switch (country)
            {
                case "us":
                    {
                        Us us = new Us();
                        Console.WriteLine(us.ConvertToPropis(ConvToInt(sum)).Trim());
                        break;
                    }
                case "ua":
                    {
                        Ua ua = new Ua();
                        Console.WriteLine(ua.ConvertToPropis(ConvToInt(sum)).Trim());
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Incorrect Country!");
                        break;
                    }

            }

        }
    }
}
