using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCurrencyConverter.Intefaces
{
    interface ICurrencyInfo
    {
        public string GetName();
        public float GetFactor();
        public float GetRatio();
        public string GetCode();
    }
}
