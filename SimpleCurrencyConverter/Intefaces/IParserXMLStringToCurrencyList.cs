using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCurrencyConverter.Intefaces
{
    interface IXMLURLToCurrencyList
    {
        public List<ICurrencyInfo> ParseFromURL(string url);
    }
}
