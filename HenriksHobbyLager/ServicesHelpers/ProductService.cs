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
                Name = ConsoleHelper.ReadInput("Namn"),
                Price = decimal.Parse(ConsoleHelper.ReadInput("Pris")),
                Stock = int.Parse(ConsoleHelper.ReadInput("Antal i lager")),
                Category = ConsoleHelper.ReadInput("Kategori")
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
            var id = int.Parse(ConsoleHelper.ReadInput("Ange produkt-ID att uppdatera"));
            var product = _repository.GetById(id);

            if (product == null)
            {
                ConsoleHelper.PrintMessage("Produkten hittades inte.");
                return;
            }

            product.Name = ConsoleHelper.ReadInput("Nytt namn (lämna tomt för att behålla)") ?? product.Name;
            product.Price = decimal.TryParse(ConsoleHelper.ReadInput("Nytt pris"), out var price) ? price : product.Price;
            product.Stock = int.TryParse(ConsoleHelper.ReadInput("Ny lagerstatus"), out var stock) ? stock : product.Stock;
            product.Category = ConsoleHelper.ReadInput("Ny kategori (lämna tomt för att behålla)") ?? product.Category;

            _repository.Update(product);
            ConsoleHelper.PrintMessage("Produkten har uppdaterats!");
        }

        public void DeleteProduct()
        {
            var id = int.Parse(ConsoleHelper.ReadInput("Ange produkt-ID att ta bort"));
            _repository.Delete(id);
            ConsoleHelper.PrintMessage("Produkten har tagits bort!");

        }
    }
}
