using System;
using System.Xml;
using System.Net;
using System.IO;
using System.Collections.Generic;


using SimpleCurrencyConverter.Classes;
using SimpleCurrencyConverter.Intefaces;
using System.Globalization;

namespace SimpleCurrencyConverter
{
    class Program
    {
        Program instance = null;
        private Program() { }

        public Program GetInstance()
        {
            if( instance == null )
                return new Program();
            else
                return GetInstance();
        }



        static void Main( string[] args )
        {

            List<ICurrencyInfo> cList = new List<ICurrencyInfo>();

            string url = "https://www.nbp.pl/kursy/xml/lasta.xml";
            string result;

            result = new WebClient().DownloadString( url );


            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml( result );

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
                    cList.Add( new CurrencyInfo( name , code , ratio , factor ) );
                }

            }

            cList.Add( new CurrencyInfo( "polski złoty" , "PLN" , 1f , 1 ) );
            foreach( var c in cList )
                Console.WriteLine( c.GetName() + "  " + c.GetCode() + "  " + c.GetRatio() + "  " + c.GetFactor() + "  " );

        }
    }
}
