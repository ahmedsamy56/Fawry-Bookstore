namespace Quantum_Bookstore.Service
{
    public class MailService
    {
        public static void SendEBook(string title, string fileType, string email)
        {
            Console.WriteLine($"MailService excuted '{title}', {fileType}, {email}");
            Console.WriteLine("***********************************************");
        }

    }
}
