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
            if( classInstance != null )
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
            try
            {
                ICurrencyInfo currencyFound = currencyList.Find( x => code == x.GetCode() );

                    return currencyFound;
            }
            catch( ArgumentNullException e )
            {
                throw e;
            }

        }

        public ICurrencyInfo GetCurrencyByName( string name )
        {
            try
            {
                ICurrencyInfo currencyFound = currencyList.Find( x => name == x.GetName() );

                return currencyFound;

            }
            catch( ArgumentNullException e )
            {
                throw e;
            }
        }

        public void UpdateCurrencyList( string url )
        {
            IXMLStringToCurrencyList parser = new XMLParser();
            ITextDownloader textDowloader = new XMLStringDownloader();


            currencyList = parser.ParseFromURL( url , textDowloader );
        }

    }
}
