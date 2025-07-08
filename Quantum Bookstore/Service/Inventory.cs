using Quantum_Bookstore.Entities.Abstracts;

namespace Quantum_Bookstore.Service
{
    public class Inventory
    {
        #region Fields
        private readonly Dictionary<string, Book> books = new();
        #endregion

        #region Functions
        public void AddBook(Book book)
        {
            if (books.ContainsKey(book.ISBN))
            {
                Console.WriteLine($"Book with ISBN :{book.ISBN} already exists");
                return;
            }
            books[book.ISBN] = book;
            Console.WriteLine($"'{book.Title}' Added successfully.");
        }

        public List<Book> RemoveOutdatedBooks(int maxYears)
        {
            int currentYear = DateTime.Now.Year;
            var outdated = books.Values.Where(b => currentYear - b.PublishedYear > maxYears).ToList();
            foreach (var book in outdated)
            {
                books.Remove(book.ISBN);
                Console.WriteLine($"Removed outdated book '{book.Title}' ({book.PublishedYear}).");
            }
            return outdated;
        }

        public decimal BuyBook(string isbn, int quantity, string email, string address)
        {
            if (!books.TryGetValue(isbn, out var book))
            {
                throw new Exception($"Book with ISBN {isbn} not found");
            }
            if (!book.IsForSale)
            {
                throw new Exception($"Book '{book.Title}' is not for sale");
            }
            if (!book.CanBuy(quantity))
            {
                throw new Exception($"Not enough stock of '{book.Title}'");
            }
            book.OnBuy(quantity);
            decimal total = book.Price * quantity;
            Console.WriteLine($"Sold {quantity} copy of '{book.Title}' \nPaid amount: {total}");
            book.ProcessDelivery(email, address, quantity);
            return total;
        }

        public void PrintInventory()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Current Inventory:");
            foreach (var book in books.Values)
            {
                Console.WriteLine($"{book.Title} ({book.PublishedYear}) - ISBN: {book.ISBN} - Price: {book.Price} - For Sale: {book.IsForSale}");
            }
            Console.WriteLine("-----------------------------------------------");
        }
        #endregion
    }
}

