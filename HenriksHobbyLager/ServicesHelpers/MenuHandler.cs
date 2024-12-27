using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenriksHobbyLager.ServicesHelpers
{

    public class MenuHandler // Hanterar ShowMenu och HandleMenuChoice istället för att ha dem i Main. 
    {
        private readonly ProductService _service;

        public MenuHandler(ProductService service)
        {
            _service = service;
        }

        public void ShowMenu()
        {
            ConsoleHelper.PrintMessage("=== Henriks HobbyLager™ ===");
            ConsoleHelper.PrintMessage("1. Visa alla produkter");
            ConsoleHelper.PrintMessage("2. Sök produkt");
            ConsoleHelper.PrintMessage("3. Lägg till produkt");
            ConsoleHelper.PrintMessage("4. Uppdatera produkt");
            ConsoleHelper.PrintMessage("5. Ta bort produkt");
            ConsoleHelper.PrintMessage("6. Avsluta");
        }

        public void HandleMenuChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    _service.ShowAllProducts();
                    break;
                case "2":

                    _service.SearchProduct();
                    break;
                case "3":
                    _service.AddProduct();
                    break;
                case "4":
                    _service.UpdateProduct();
                    break;
                case "5":
                    _service.DeleteProduct();
                    break;
                case "6":
                    ConsoleHelper.PrintMessage("Avslutar programmet...");
                    Environment.Exit(0); // Avslutar programmet
                    break;
                default:
                    ConsoleHelper.PrintMessage("Ogiltigt val, försök igen.");
                    break;// om valet är 0 eller större än 6
            }

            ConsoleHelper.PrintMessage("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }
    }
}
