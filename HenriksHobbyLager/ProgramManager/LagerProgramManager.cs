using HenriksHobbyLager.Database;
using HenriksHobbyLager.Repositories;
using HenriksHobbyLager.ServicesHelpers;

namespace HenriksHobbyLager.ProgramManager
{
    internal class LagerProgramManager
    {
        public class HenriksHobbyLagerProgramManager//Logiken för programmet.
        {
            public void Run()
            {
                // Testa anslutningen till databasen
                using (var context = new AppDbContext())
                {
                    var toys = context.Products.ToList(); // Hämta alla rader från tabellen Toys
                    Console.WriteLine($"Hittade {toys.Count} leksaker i databasen!");

                    foreach (var toy in toys)
                    {
                        Console.WriteLine($"Name: {toy.Name}, Price: {toy.Price}, Category: {toy.Category},  Stock: {toy.Stock}");
                    }
                }

                // Starta repositories, services och menyhanteraren
                var repository = new ProductRepository(); // Hanterar data
                var productService = new ProductService(repository); // Hanterar logik
                var menuHandler = new MenuHandler(productService); // Hanterar menyval

                // Huvudloopen för programmet
                while (true)
                {
                    menuHandler.ShowMenu(); // Visa menyn
                    var choice = ConsoleHelper.ReadInput("Välj ett alternativ 1-6"); // Läs in val
                    menuHandler.HandleMenuChoice(choice);
                    if (0 < 6)// om valet är 0 eller större än 6 

                        Console.WriteLine("Fel val, vänligen försök igen");//felmeddelande 
                }
            }
        }
    }
}
