using System;
using System.Collections.Generic;
using System.Text;

using SimpleCurrencyConverter.Intefaces;

namespace SimpleCurrencyConverter.Classes
{
    class CurrencyInfo : ICurrencyInfo
    {
        string name;
        string code;
        float ratio;
        int factor;

        public CurrencyInfo(string name, string code, float ratio, int factor)
        {
            this.name = name;
            this.code = code;
            this.ratio = ratio;
            this.factor = factor;
        }

        public CurrencyInfo()
        {
            this.name = "";
            this.code = "";
            this.ratio = -1f;
            this.factor = -1;
        }

        public string GetName()
        {
            return this.name;
        }

        public float GetFactor()
        {
            return this.factor;
        }
        public float GetRatio()
        {
            return this.ratio;
        }

        public string GetCode()
        {
            return this.code;
        }


    }
}
