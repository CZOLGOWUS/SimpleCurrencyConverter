using System;
using System.Collections.Generic;
using System.Text;

using SimpleCurrencyConverter.Intefaces;

namespace SimpleCurrencyConverter.Classes
{
    class PLNBasedCurrencyRatesContainer : ICurrencyListContainer
    {

        #region Singeton setup

        private static PLNBasedCurrencyRatesContainer classInstance = null;
        private PLNBasedCurrencyRatesContainer() { }
        public static PLNBasedCurrencyRatesContainer GetInstance()
        {
            if( classInstance != null)
            {
                return classInstance;
            }
            else
            {
                classInstance = new PLNBasedCurrencyRatesContainer();
                return classInstance;
            }
        }

        #endregion

        private List<ICurrencyInfo> currencyList = new List<ICurrencyInfo>();

        public IReadOnlyCollection<ICurrencyInfo> GetAll()
        {

            if( currencyList != null )
                return this.currencyList.AsReadOnly();
            else
                return null;
        }

        public ICurrencyInfo GetCurrencyByCode( string code )
        {

            ICurrencyInfo currencyFound = currencyList.Find( x => code == x.GetCode() );

            if( currencyFound == null )
                throw new ArgumentException( "\nthere is no currency with this code\n" );
            else
                return currencyFound;
        }

        public ICurrencyInfo GetCurrencyByName(string name)
        {

            ICurrencyInfo currencyFound = currencyList.Find( x => name == x.GetName() );

            if( currencyFound == null )
                throw new ArgumentException( "\nthere is no currency with this name\n" );
            else
                return currencyFound;
        }

        public void UpdateCurrencyList(string url, IXMLStringToCurrencyList urlXMLParser , ITextReceiver textDownloader)
        {
            currencyList = urlXMLParser.ParseFromURL( url , textDownloader);
        }

    }
}
