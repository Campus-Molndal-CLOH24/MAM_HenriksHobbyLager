using HenriksHobbyLager.Database;
using HenriksHobbyLager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenriksHobbyLager.Repositories
{
    public class ProductRepository
    {
        private object? id;

        public IEnumerable<Product> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Products.ToList(); // Hämtar alla produkter från databasen
            }
        }

        public Product GetById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Products.FirstOrDefault(p => p.Id == id); // Hämtar produkt med specifikt ID
            }
        }

        public IEnumerable<Product> Search(string searchTerm)
        {
            using (var context = new AppDbContext())
            {
                string lowerSearchTerm = searchTerm.ToLower(); // Konverterar söktermen till små bokstäver

                return context.Products
                    .Where(p => p.Name.ToLower().Contains(lowerSearchTerm)) // Jämför med små bokstäver
                    .ToList(); // Konvertera till en lista för att returnera resultaten
            }
        }


        public void Add(Product product)
        {
            using (var context = new AppDbContext())
            {
                product.Created = DateTime.Now; // Sätter skapelsedatum
                context.Products.Add(product); // Lägger till produkten i databasen
                context.SaveChanges(); // Sparar ändringar i databasen
            }
        }

        public void Update(Product updatedProduct)
        {
            using (var context = new AppDbContext())
            {
                var product = context.Products.Find(updatedProduct.Id);
                if (product == null)
                {

                    Console.WriteLine($"Produkt med ID {id} hittades inte.");
                }
                else
                {
                    product.Name = updatedProduct.Name;
                    product.Price = updatedProduct.Price;
                    product.Stock = updatedProduct.Stock;
                    product.Category = updatedProduct.Category;
                    product.LastUpdated = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                var product = context.Products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    Console.WriteLine($"Produkt med ID {id} hittades inte.");
                }
                else
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
            }
        }
    }
}
