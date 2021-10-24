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
                        currencyContainer.UpdateCurrencyList( url, XMLStringParser , textDownloader );
                    }
                    break;
                    case 2:
                    {
                        appInterface.PrintAll(currencyContainer);
                    }
                    break;
                    case 3:
                    {
                        string inputCode;

                        Console.WriteLine( "\nPlease input currency code and press enter:" );
                        inputCode = Console.ReadLine();

                        appInterface.PrintByCode( inputCode , currencyContainer );
                    }
                    break;
                    case 4:
                    {
                        string inputName;

                        Console.WriteLine( "\nPlease input currency name and press enter:" );
                        inputName = Console.ReadLine();

                        appInterface.PrintByName( inputName , currencyContainer );
                    }
                    break;
                    case 5:
                    {
                        string codeFrom = "",codeTo = "";
                        float amount = -1f;
                   

                        Console.WriteLine( "enter currency code to convert from\n" );
                        codeFrom = Console.ReadLine();

                        Console.WriteLine( "enter currency code to convert to\n" );
                        codeTo = Console.ReadLine();

                        Console.WriteLine( "enter the amount\n" );
                        float.TryParse(Console.ReadLine(),out amount);

                        ICurrencyInfo currencyFrom = currencyContainer.GetCurrencyByCode( codeFrom );
                        ICurrencyInfo currencyTo = currencyContainer.GetCurrencyByCode( codeTo );

                        if(codeFrom != "" && codeTo != "" && amount != -1f)
                        {
                            Console.WriteLine( amount + " " + codeFrom + " = " + CurrencyConverter.Convert( currencyFrom , currencyTo , amount ) + " " + codeTo );
                        }

                    }
                    break;
                    case 6:
                    {
                        Environment.Exit(0);
                    }
                    break;

                }
                // repeat till exit
                Console.WriteLine( "press any key to return to option Menu" );
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
