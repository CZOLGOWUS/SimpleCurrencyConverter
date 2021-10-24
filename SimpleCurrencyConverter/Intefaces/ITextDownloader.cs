using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCurrencyConverter.Intefaces
{
    interface ITextDownloader
    {
        public string GetTextString( string url );
    }
}
