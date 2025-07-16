using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Linq;

namespace KonsolProjesi1
{
    public class LoanManager
    {
        public List<Loan> ActiveLoans { get; private set; }
        public List<Loan> CompletedLoans { get; private set; }
        private int nextLoanId = 1;

        public LoanManager()
        {
            ActiveLoans = new List<Loan>();
            CompletedLoans = new List<Loan>();
        }

        public void borrowBook(int bookISBN, int readerID)
        {
            Loan loan = new Loan
            {
                LoanID = nextLoanId++,
                BookISBN = bookISBN,
                ReaderID = readerID,
                LoanDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14), // örneğin 2 hafta
                ReturnDate = null
            };

            ActiveLoans.Add(loan);
            Console.WriteLine("Book borrowed successfully.");
        }

        public void returnBook(int loanID)
        {
            Loan loan = ActiveLoans.Find(l => l.LoanID == loanID);
            if (loan != null)
            {
                loan.ReturnDate = DateTime.Now;
                ActiveLoans.Remove(loan);
                CompletedLoans.Add(loan);
                Console.WriteLine("Book returned.");
            }
            else
            {
                Console.WriteLine("Loan not found.");
            }
        }
        public void saveLoans()
        {
            string json = JsonSerializer.Serialize(ActiveLoans, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("loans.json", json);
        }
        public void loadLoans()
        {
            if (File.Exists("loans.json"))
            {
                string json = File.ReadAllText("loans.json");
                var loadedLoans = JsonSerializer.Deserialize<List<Loan>>(json);

                if (loadedLoans != null)
                {
                    ActiveLoans.Clear();
                    ActiveLoans.AddRange(loadedLoans);
                }
            }
            if (ActiveLoans.Count > 0)
            {
                nextLoanId = ActiveLoans.Max(l => l.LoanID) + 1;
            }

        }
        public void showActiveLoans()
        {
            if(ActiveLoans.Count == 0)
            {
                Console.WriteLine("There is no loans.");
                return;
            }
            foreach (var loan in ActiveLoans)
            {
                Console.WriteLine("book number {0} is loaned.", loan.BookISBN);
            }

        }
    }
}
