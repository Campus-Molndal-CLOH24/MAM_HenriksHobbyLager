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
                Console.WriteLine("Choose your database:");
                Console.WriteLine("1. MongoDB");
                Console.WriteLine("2. SQLite");
                Console.Write("Enter your choice (1 or 2): ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        //UseMongoDB();
                        break;
                    case "2":
                        // anslutningen till Sqlite databasen
                        using (var context = new SqliteDbContext())
                        {
                            context.Database.EnsureCreated(); // Skapa databasen om den inte finns
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
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                        break;
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();

                
            }
        }
    }
}
