using HenriksHobbyLager.Models;
using HenriksHobbyLager.ServicesHelpers;
using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Repositories;

namespace HenriksHobbyLager.ServicesHelpers
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _repository;

        public ProductService(ProductRepository repository)
        {
            _repository = repository;
        }

        public void AddProduct()
        {
            ConsoleHelper.PrintMessage("Lägg till en ny produkt:");

            var product = new Product
            {
                Name = ConsoleHelper.ReadStringInput("Namn"),
                Price = ConsoleHelper.ReadDecimalInput("Pris"),
                Stock = ConsoleHelper.ReadIntInput("Antal i lager"),
                Category = ConsoleHelper.ReadStringInput("Kategori")
            };

            _repository.Add(product);
            ConsoleHelper.PrintMessage("Produkten har lagts till!");
        }

        public void ShowAllProducts()
        {
            var products = _repository.GetAll();

            if (products == null || !products.Any())
            {
                ConsoleHelper.PrintMessage("Inga produkter finns i lagret.");
                return;
            }

            ConsoleHelper.PrintMessage("=== Alla produkter ===");
            ConsoleHelper.PrintProducts(products);
        }

        public void SearchProduct()
        {
            var searchTerm = ConsoleHelper.ReadInput("Ange sökterm: ").Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                ConsoleHelper.PrintMessage("Vänligen ange en sökterm");
                return;
            }

            var searchResults = _repository.Search(searchTerm);

            if (!searchResults.Any())
            {
                ConsoleHelper.PrintMessage("Inga produkter hittades.");
                return;
            }

            ConsoleHelper.PrintMessage("Produkter som matchar din sökning:");
            ConsoleHelper.PrintProducts(searchResults);
        }


        public void UpdateProduct()
        {
            int id;
            do
            {
                var input = ConsoleHelper.ReadInput("Ange produkt-ID att uppdatera");
                if (int.TryParse(input, out id) && id > 0)
                {
                    break; // Valid ID entered
                }
                Console.WriteLine("Felaktigt ID. Ange ett giltigt produkt-ID som är större än 0.");
            } while (true);
            var product = _repository.GetById(id);
            if (product == null)
            {
                ConsoleHelper.PrintMessage("Produkten hittades inte.");
                return;
            }

            var newName = ConsoleHelper.ReadInput("Nytt namn (lämna tomt för att behålla)");
            if (!string.IsNullOrEmpty(newName))
            {
                product.Name = newName;
            }
            var newPriceInput = ConsoleHelper.ReadInput("Nytt pris (lämna tomt för att behålla)");
            if (decimal.TryParse(newPriceInput, out var newPrice))
            {
                product.Price = newPrice;
            }
            var newStockInput = ConsoleHelper.ReadInput("Ny lagerstatus (lämna tomt för att behålla)");
            if (int.TryParse(newStockInput, out var newStock))
            {
                product.Stock = newStock;
            }
            var newCategory = ConsoleHelper.ReadInput("Ny kategori (lämna tomt för att behålla)");
            if (!string.IsNullOrEmpty(newCategory))
            {
                product.Category = newCategory;
            }

            _repository.Update(product);
            ConsoleHelper.PrintMessage("Produkten har uppdaterats!");
        }

        public void DeleteProduct()
        {
            var id = int.Parse(ConsoleHelper.ReadInput("Ange produkt-ID att ta bort"));
            _repository.Delete(id);
        }
    }
}