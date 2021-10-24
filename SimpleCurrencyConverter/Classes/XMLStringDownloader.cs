using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

using SimpleCurrencyConverter.Intefaces;

namespace SimpleCurrencyConverter.Classes
{
    class XMLStringDownloader : ITextDownloader
    {
        public string GetTextString( string url )
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;

            return webClient.DownloadString( url );
        }
    }
}
