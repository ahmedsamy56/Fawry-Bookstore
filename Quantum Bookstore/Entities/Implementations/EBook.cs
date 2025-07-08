using Quantum_Bookstore.Entities.Abstracts;
using Quantum_Bookstore.Service;

namespace Quantum_Bookstore.Entities.Implementations
{
    public class EBook : Book
    {
        #region Fields
        public override bool IsForSale => true;
        public string FileType { get; set; }
        #endregion

        #region Constructors
        public EBook(string isbn, string title, int publishedYear, decimal price, string fileType)
            : base(isbn, title, publishedYear, price)
        {
            FileType = fileType;
        }
        #endregion

        #region Functions
        public override void ProcessDelivery(string email, string address, int quantity)
        {
            MailService.SendEBook(Title, FileType, email);
        }
        #endregion
    }
}
