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
            Encoding.RegisterProvider( CodePagesEncodingProvider.Instance );

            WebClient webClient = new WebClient();
            webClient.Encoding = GetEncoding( webClient.DownloadData( url ) );

            var data = Encoding.Convert( webClient.Encoding , Encoding.UTF8, webClient.DownloadData( url ) );

            return Encoding.UTF8.GetString( data );
        }

        public Encoding GetEncoding(byte[] data)
        {
            Encoding encoding;
            using( var stream = new MemoryStream( data ) )
            {
                using( var xmlreader = new XmlTextReader( stream ) )
                {
                    xmlreader.MoveToContent();
                    encoding = xmlreader.Encoding;
                }
            }

            return encoding;
        }

    }
}
