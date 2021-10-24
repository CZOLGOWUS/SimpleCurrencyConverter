using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;

using SimpleCurrencyConverter.Intefaces;

namespace SimpleCurrencyConverter.Classes
{
    class XMLParser : IXMLURLToCurrencyList
    {
        public List<ICurrencyInfo> ParseFromURL( string url )
        {
            XmlDocument xmlDoc = new XmlDocument();
            List<ICurrencyInfo> currencyList = new List<ICurrencyInfo>();

            xmlDoc.LoadXml( new XMLStringDownloader().GetTextString(url) );

            foreach( XmlNode node in xmlDoc.DocumentElement.ChildNodes )
            {
                string name = "";
                string code = "";
                float ratio = -1f;
                int factor = -1;

                foreach( XmlNode childNode in node )
                {
                    if( childNode.Name == "nazwa_waluty" )
                        name = childNode.InnerText;
                    else if( childNode.Name == "przelicznik" )
                        factor = int.Parse( childNode.InnerText );
                    else if( childNode.Name == "kurs_sredni" )
                        ratio = float.Parse( childNode.InnerText , CultureInfo.InvariantCulture );
                    else if( childNode.Name == "kod_waluty" )
                        code = childNode.InnerText;
                }


                if( name != "" && code != "" && ratio != -1f && factor != -1 )
                {
                    currencyList.Add( new CurrencyInfo( name , code , ratio , factor ) );
                }

            }

            currencyList.Add( new CurrencyInfo( "polski złoty" , "PLN" , 1f , 1 ) );

            return currencyList;
        }
    }
}
