using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCurrencyConverter.Intefaces
{
    interface ICurrencyListContainer
    {
        public ICurrencyInfo GetCurrency(string code);
        public IReadOnlyCollection<ICurrencyInfo> GetAll();
    }
}
