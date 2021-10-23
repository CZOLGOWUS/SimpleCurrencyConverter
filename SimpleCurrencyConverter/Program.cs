using System;

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
