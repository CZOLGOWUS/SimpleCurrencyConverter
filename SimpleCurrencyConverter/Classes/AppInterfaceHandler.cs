using System;
using System.Collections.Generic;
using System.Text;

using SimpleCurrencyConverter.Intefaces;

namespace SimpleCurrencyConverter.Classes
{
    class AppInterfaceHandler
    {
        #region singelton Setup

        private static AppInterfaceHandler classInstace = null;
        private AppInterfaceHandler() { }

        public static AppInterfaceHandler GetInstace()
        {
            if( classInstace == null )
            {
                classInstace = new AppInterfaceHandler();
                return classInstace;
            }
            else
                return classInstace;
        }

        #endregion





        public int HandleMenu()
        {
            int intInput = -1;
            ConsoleKeyInfo input;

            Console.WriteLine( "Please input the number 1-5" );
            Console.WriteLine( "1. Update currency list" );
            Console.WriteLine( "2. Print ALL avialable currency info" );
            Console.WriteLine( "3. Print Currency info by code" );
            Console.WriteLine( "4. Print Currency info by name" );
            Console.WriteLine( "5. Convert Currency" );
            Console.WriteLine( "6. Exit\n\n" );

            input = Console.ReadKey();
            Console.WriteLine( "\n" );

            if( char.IsDigit( input.KeyChar ) )
                intInput = int.Parse( input.KeyChar.ToString() );
            else
                intInput = -1;

            if( intInput > 0 && intInput < 7 )
                return intInput;
            else
                return -1;
        }



        public void PrintAll( ICurrencyListContainer container )
        {
           IReadOnlyCollection<ICurrencyInfo> tempList = container.GetAll();

            if( tempList == null )
            {
                Console.WriteLine( "there are no currencies aviable" );
                return;
            }

            foreach( ICurrencyInfo currency in tempList )
            {
                Console.WriteLine( "name: " + currency.GetName() +
                    "\ncode: " + currency.GetCode() +
                    "\nratio: " + currency.GetRatio() +
                    "\nfactor: " + currency.GetFactor()  + "\n");
            }

        }



        public void PrintByCode(string code, ICurrencyListContainer container )
        {
            try
            {
                ICurrencyInfo currency = container.GetCurrencyByCode( code );

                Console.WriteLine( "name: " + currency.GetName() +
                "\ncode: " + currency.GetCode() +
                "\nratio: " + currency.GetRatio() +
                "\nfactor: " + currency.GetFactor() + "\n" );
            }
            catch(ArgumentException e)
            {
                Console.WriteLine( e.Message );
            }

        }


        public void PrintByName( string name , ICurrencyListContainer container )
        {
            try
            {
                ICurrencyInfo currency = container.GetCurrencyByName( name );

                Console.WriteLine( "name: " + currency.GetName() +
                "\ncode: " + currency.GetCode() +
                "\nratio: " + currency.GetRatio() +
                "\nfactor: " + currency.GetFactor() + "\n" );
            }
            catch( ArgumentException e )
            {
                Console.WriteLine( e.Message );
            }
        }


    }
}
