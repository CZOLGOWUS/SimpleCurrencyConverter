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
            ITextDownloader textDownloader = new XMLStringDownloader();

            int input = -1;
            while( !isExitSelected )
            {
                input = -1;

                while( input == -1 )
                {
                    input = appInterface.HandleMenu();
                }


                switch( input )
                {
                    case 1: //update
                    {
                        currencyContainer.UpdateCurrencyList( url );
                    }
                    break;
                    case 2: //print all
                    {
                        appInterface.PrintAll( currencyContainer );
                    }
                    break;
                    case 3: //Print Currency by Code
                    {
                        try
                        {
                            appInterface.PrintByCode( appInterface.AskForCurrencyCode().ToUpper() , currencyContainer );
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
                    case 4: //print currency by Name
                    {
                        try
                        {
                            appInterface.PrintByName( appInterface.AskForCurrencyName().ToUpper() , currencyContainer );
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
                    case 5: // Convert currency
                    {
                        string codeFrom = "", codeTo = "";
                        float amount = -1f;

                        appInterface.AskForConvertionData( out codeFrom , out codeTo , out amount );

                        try
                        {
                            ICurrencyInfo currencyFrom = currencyContainer.GetCurrencyByCode( codeFrom.ToUpper() );
                            ICurrencyInfo currencyTo = currencyContainer.GetCurrencyByCode( codeTo.ToUpper() );

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
                    case 6: //exit application
                    {
                        Environment.Exit( 0 );
                    }
                    break;
                    default:
                    {
                        appInterface.PrintWrongOptionArgumentMessege( input );
                    }
                    break;

                }

                appInterface.EndOfLoopClear();
            }

        }

    }
}
