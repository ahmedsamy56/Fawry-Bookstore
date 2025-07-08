namespace Quantum_Bookstore.Service
{
    public class ShippingService
    {
        public static void ShipBook(string title, int quantity, string address)
        {
            Console.WriteLine($"ShippingService excuted {title}, {quantity}, {address}");
            Console.WriteLine("***********************************************");

        }
    }
}
