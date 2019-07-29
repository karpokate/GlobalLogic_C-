using System;
using System.Collections.Generic;
using System.Text;

namespace propis
{
    abstract class Country
    {
            public string[][] name;
            public string[] number;
            public abstract string Conv(int value, int i);

            public abstract string Declension(int value, int i);

            public abstract string ConvertToPropis(int[] value);
    }
}
