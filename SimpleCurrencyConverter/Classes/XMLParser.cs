using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;

using SimpleCurrencyConverter.Intefaces;

namespace SimpleCurrencyConverter.Classes
{
    class XMLParser : IXMLStringToCurrencyList
    {
        public List<ICurrencyInfo> ParseFromURL( string url, ITextDownloader textDownloader )
        {
            XmlDocument xmlDoc = new XmlDocument();
            List<ICurrencyInfo> currencyList = new List<ICurrencyInfo>();

            xmlDoc.LoadXml( textDownloader.GetTextString(url) );

            foreach( XmlNode node in xmlDoc.DocumentElement.ChildNodes )
            {
                string tempName = "";
                string tempCode = "";
                float tempRatio = -1f;
                int tempFactor = -1;

                foreach( XmlNode childNode in node )
                {
                    if( childNode.Name == "nazwa_waluty" )
                        tempName = childNode.InnerText.ToUpper();
                    else if( childNode.Name == "przelicznik" )
                        int.TryParse( childNode.InnerText.ToUpper() ,out tempFactor);
                    else if( childNode.Name == "kurs_sredni" )
                        float.TryParse( childNode.InnerText , out tempRatio);
                    else if( childNode.Name == "kod_waluty" )
                        tempCode = childNode.InnerText;
                }


                if( tempName != "" && tempCode != "" && tempRatio != -1f && tempFactor != -1 )
                {
                    currencyList.Add( new CurrencyInfo( tempName , tempCode , tempRatio , tempFactor ) );
                }

            }

            currencyList.Add( new CurrencyInfo( "POLSKI ZŁOTY" , "PLN" , 1f , 1 ) );

            return currencyList;
        }
    }
}
