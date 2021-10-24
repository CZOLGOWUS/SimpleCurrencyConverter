using System;
using System.Xml;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Text;


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


        }
    }
}
