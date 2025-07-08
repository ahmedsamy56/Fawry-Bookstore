using Quantum_Bookstore.Entities.Abstracts;
using Quantum_Bookstore.Service;

namespace Quantum_Bookstore.Entities.Implementations
{
    public class PaperBook : Book
    {
        #region Fields
        public override bool IsForSale => true;
        public int Stock { get; set; }
        #endregion

        #region Constructors
        public PaperBook(string isbn, string title, int publishedYear, decimal price, int stock)
            : base(isbn, title, publishedYear, price)
        {
            Stock = stock;
        }
        #endregion

        #region Functions
        public override void ProcessDelivery(string email, string address, int quantity)
        {
            ShippingService.ShipBook(Title, quantity, address);
        }
        public override bool CanBuy(int quantity) => Stock >= quantity;
        public override void OnBuy(int quantity) => Stock -= quantity;
        #endregion
    }
}
