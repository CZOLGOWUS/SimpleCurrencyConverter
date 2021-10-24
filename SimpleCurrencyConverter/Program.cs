using System;

using SimpleCurrencyConverter.Classes;
using SimpleCurrencyConverter.Intefaces;

namespace SimpleCurrencyConverter
{

    class Program
    {

        static void Main( string[] args )
        {
            string url = "https://www.nbp.pl/kursy/xml/lasta.xml";

            bool isExitSelected = false;
            AppInterfaceHandler appInterface = AppInterfaceHandler.GetInstace();
            PLNBasedCurrencyRatesContainer currencyContainer = PLNBasedCurrencyRatesContainer.GetInstance();

            IXMLStringToCurrencyList XMLStringParser = new XMLParser();
            ITextReceiver textDownloader = new XMLStringDownloader();

            int input = -1;
            while( !isExitSelected )
            {
                input = -1;
                // Handle Menu/choice
                while( input == -1 )
                {
                    input = appInterface.HandleMenu();

                    if( input == -1 )
                        Console.WriteLine( "input is out of range" );
                }

                // Do the functionality depending on input

                switch( input )
                {
                    case 1:
                    {
                        currencyContainer.UpdateCurrencyList( url , XMLStringParser , textDownloader );
                    }
                    break;
                    case 2:
                    {
                        appInterface.PrintAll( currencyContainer );
                    }
                    break;
                    case 3:
                    {
                        try
                        {
                            appInterface.PrintByCode( appInterface.AskForCurrencyCode() , currencyContainer );
                        }
                        catch( ArgumentNullException e )
                        {
                            Console.WriteLine( e.Message + "\nPlease update currency list" );
                        }
                        catch( NullReferenceException e )
                        {
                            Console.WriteLine( e.Message + "\nPlease update currency list" );
                        }
                    }
                    break;
                    case 4:
                    {
                        try
                        {
                            appInterface.PrintByName( appInterface.AskForCurrencyName() , currencyContainer );
                        }
                        catch( ArgumentNullException e )
                        {
                            Console.WriteLine( e.Message + "\nPlease update currency list" );
                        }
                        catch( NullReferenceException e )
                        {
                            Console.WriteLine( e.Message + "\nPlease update currency list" );
                        }
                    }
                    break;
                    case 5:
                    {
                        string codeFrom = "", codeTo = "";
                        float amount = -1f;

                        appInterface.AskForConvertionData( out codeFrom , out codeTo , out amount );

                        try
                        {
                            ICurrencyInfo currencyFrom = currencyContainer.GetCurrencyByCode( codeFrom );
                            ICurrencyInfo currencyTo = currencyContainer.GetCurrencyByCode( codeTo );

                            float convertedAmount = CurrencyConverter.Convert( currencyFrom , currencyTo , amount );
                            appInterface.PrintConvertionResult( codeFrom , codeTo , amount , convertedAmount );
                        }
                        catch( ArgumentNullException e )
                        {
                            Console.WriteLine( e.Message + "\nPlease update currency list" );
                        }
                        catch( NullReferenceException e )
                        {
                            Console.WriteLine( e.Message + "\nPlease update currency list" );
                        }

                    }
                    break;
                    case 6:
                    {
                        Environment.Exit( 0 );
                    }
                    break;

                }
                // repeat till exit
                appInterface.EndOfLoopClear();
            }

        }


    }
}
