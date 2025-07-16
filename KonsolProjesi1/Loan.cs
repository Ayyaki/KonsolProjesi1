using System;
namespace KonsolProjesi1
{
    public class Loan
    {
        public int LoanID { get; set; }              // Her loan için benzersiz ID
        public int BookISBN { get; set; }              // Ödünç alınan kitap
        public int ReaderID { get; set; }              // Kitabı ödünç alan kullanıcı
        public DateTime LoanDate { get; set; }       // Ne zaman alındı?
        public DateTime DueDate { get; set; }        // Son teslim tarihi
        public DateTime? ReturnDate { get; set; }    // Geri verildiyse, ne zaman verildi?
        public bool IsReturned => ReturnDate != null;
    }
}
