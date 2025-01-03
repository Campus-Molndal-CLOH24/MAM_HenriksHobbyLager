﻿using HenriksHobbyLager.Models;

namespace HenriksHobbyLager.ServicesHelpers
{
    public static class ConsoleHelper//För att slippa alla console.writeline och console.readline i Program
        {
            public static void PrintProduct(Product product)//Skriver ut en produkt
            {
                Console.WriteLine($"ID: {product.Id}");
                Console.WriteLine($"Namn: {product.Name}");
                Console.WriteLine($"Pris: {product.Price:C}");
                Console.WriteLine($"Antal i lager: {product.Stock}");
                Console.WriteLine($"Kategori: {product.Category}");
                Console.WriteLine($"Skapad: {product.Created}");
                Console.WriteLine($"Senast uppdaterad: {product.LastUpdated}");
                Console.WriteLine(); // Lägger till en tom rad för att skilja produkterna
            }

            public static void PrintProducts(IEnumerable<Product> products)
            {
                foreach (var product in products)
                {
                    PrintProduct(product);
                }
            }

            public static string ReadInput(string prompt)//Läser in en sträng från användaren tex namn, pris, kategori
            {
                Console.Write($"{prompt}: ");
                return Console.ReadLine();
            }

            public static void PrintMessage(string message)
            {
                Console.WriteLine(message);
            }
        }
    }
