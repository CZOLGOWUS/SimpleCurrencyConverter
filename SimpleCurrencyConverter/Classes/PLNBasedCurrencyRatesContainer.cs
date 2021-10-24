using System;
using System.Collections.Generic;
using System.Text;

using SimpleCurrencyConverter.Intefaces;

namespace SimpleCurrencyConverter.Classes
{
    class PLNBasedCurrencyRatesContainer : ICurrencyListContainer
    {
        private List<ICurrencyInfo> currencyList = null;

        public IReadOnlyCollection<ICurrencyInfo> GetAll()
        {
            return this.currencyList.AsReadOnly(); 
        }

        public ICurrencyInfo GetCurrency( string code )
        {
            return currencyList.Find( x => code == x.GetCode() );
        }

        public void UpdateCurrencyList(string url, IXMLURLToCurrencyList urlXMLParser)
        {
            currencyList = urlXMLParser.ParseFromURL( url );
        }

    }
}
