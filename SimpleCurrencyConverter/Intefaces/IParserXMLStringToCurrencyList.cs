using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCurrencyConverter.Intefaces
{
    interface IXMLStringToCurrencyList
    {
        public List<ICurrencyInfo> ParseFromURL(string url, ITextDownloader textDownloader);
    }
}
