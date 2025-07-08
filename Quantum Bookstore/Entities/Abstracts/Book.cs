namespace Quantum_Bookstore.Entities.Abstracts
{
    public abstract class Book
    {
        #region Fields
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int PublishedYear { get; set; }
        public decimal Price { get; set; }
        public abstract bool IsForSale { get; }
        #endregion

        #region Constructors
        protected Book(string isbn, string title, int publishedYear, decimal price)
        {
            ISBN = isbn;
            Title = title;
            PublishedYear = publishedYear;
            Price = price;
        }
        #endregion

        #region Functions
        public abstract void ProcessDelivery(string email, string address, int quantity);
        public virtual bool CanBuy(int quantity) => true;
        public virtual void OnBuy(int quantity) { }
        #endregion
    }
}
