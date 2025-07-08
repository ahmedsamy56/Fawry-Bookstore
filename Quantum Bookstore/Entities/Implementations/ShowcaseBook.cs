using Quantum_Bookstore.Entities.Abstracts;

namespace Quantum_Bookstore.Entities.Implementations
{
    public class ShowcaseBook : Book
    {
        #region Fields
        public override bool IsForSale => false;
        #endregion

        #region Constructors
        public ShowcaseBook(string isbn, string title, int publishedYearear, decimal price)
            : base(isbn, title, publishedYearear, price)
        {

        }
        #endregion

        #region Functions
        public override void ProcessDelivery(string email, string address, int quantity)
        {
            Console.WriteLine($"'{Title}' is a ShowcaseBook book which is not for sale and cannot be delivered.");
        }
        #endregion
    }
}
