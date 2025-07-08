using Quantum_Bookstore.Entities.Implementations;
using Quantum_Bookstore.Service;

namespace Quantum_Bookstore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inventory = new Inventory();
            // Add books
            inventory.AddBook(new PaperBook("111", "C# book", 2019, 50, 10));
            inventory.AddBook(new EBook("222", "cloud book", 2021, 30, "PDF"));
            inventory.AddBook(new ShowcaseBook("333", "TypeScript book", 2022, 0));
            inventory.AddBook(new ShowcaseBook("444", "Azur book", 1950, 0));
            inventory.AddBook(new PaperBook("555", "php book", 1990, 50, 10));
            inventory.AddBook(new EBook("666", "java book", 2000, 30, "PDF"));
            inventory.AddBook(new EBook("666", "existing ISBN", 2000, 30, "PDF"));

            inventory.PrintInventory();

            // Remove outdated books 
            inventory.RemoveOutdatedBooks(20);
            inventory.PrintInventory();

            // Buy a paper book
            try
            {
                inventory.BuyBook("111", 2, "ahmed@gmail.com", "123 cairo");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Buy an ebook
            try
            {
                inventory.BuyBook("222", 1, "ahmed@gmail.com", "");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Try to buy a showcase book
            try
            {
                inventory.BuyBook("333", 1, "ahmed@gmail.com", "");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Not enough stock
            try
            {
                inventory.BuyBook("111", 9, "ahmed@gmail.com", "123 cairo");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
