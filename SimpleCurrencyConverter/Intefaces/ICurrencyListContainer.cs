using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCurrencyConverter.Intefaces
{
    interface ICurrencyListContainer
    {
        public ICurrencyInfo GetCurrencyByCode(string code);
        public ICurrencyInfo GetCurrencyByName(string name);
        public IReadOnlyCollection<ICurrencyInfo> GetAll();
    }
}
