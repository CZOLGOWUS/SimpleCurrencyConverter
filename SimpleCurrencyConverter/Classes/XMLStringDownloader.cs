using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

using System.Xml;

using SimpleCurrencyConverter.Intefaces;

namespace SimpleCurrencyConverter.Classes
{
    class XMLStringDownloader : ITextDownloader
    {
        public string GetTextString( string url )
        {
            WebClient webClient = new WebClient();
            Encoding isoEncoding = Encoding.GetEncoding( "ISO-8859-1" ); // ISO-8859-2 is throwing an error that it is not supported...
            webClient.Encoding = isoEncoding;

            var data = Encoding.Convert(isoEncoding , Encoding.UTF8, webClient.DownloadData(url));
            string stringData = Encoding.UTF8.GetString(data);

            Console.WriteLine( stringData );

            return stringData;
        }
    }
}
