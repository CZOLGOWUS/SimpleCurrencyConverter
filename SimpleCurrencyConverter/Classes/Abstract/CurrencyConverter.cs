using System;
using System.Collections.Generic;
using System.Text;

using SimpleCurrencyConverter.Intefaces;

namespace SimpleCurrencyConverter.Classes
{
    abstract class CurrencyConverter
    {
        public static float Convert(ICurrencyInfo c1, ICurrencyInfo c2, float amount)
        {
            return (amount * c1.GetFactor() * c1.GetRatio()) / (c2.GetRatio() * c2.GetFactor());
        }
    }
}
