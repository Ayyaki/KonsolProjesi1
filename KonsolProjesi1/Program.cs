using System;

namespace KonsolProjesi1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var library = Library.Instance;

            // Sample writers
            Writer writer1 = new Writer("Alice Monroe", 31783);
            Writer writer2 = new Writer("David Zhang", 48101);
            library.writerManager.AddWriter(writer1);
            library.writerManager.AddWriter(writer2);

            // Sample readers
            Reader reader1 = new PremiumReader("Emily Carter", 34661);
            Reader reader2 = new CasualReader("John Smith", 66674);
            Reader reader3 = new CasualReader("Sarah Kim", 56592);
            Reader reader4 = new CasualReader("Michael Brown", 50928);
            library.readerManager.registerReader(reader1);
            library.readerManager.registerReader(reader2);
            library.readerManager.registerReader(reader3);
            library.readerManager.registerReader(reader4);

            // Sample books
            Book book1 = new Book("The Silent World", 84165, writer1.ID, reader1.ID);
            Book book2 = new Book("Echoes of Light", 92030, writer2.ID, reader1.ID);
            Book book3 = new Book("The Forgotten Code", 76139, writer1.ID, reader2.ID);
            Book book4 = new Book("Dust and Dreams", 82169, writer2.ID, reader3.ID);
            Book book5 = new Book("Fading Skies", 88200, writer1.ID, reader4.ID);
            Book book6 = new Book("Broken Horizon", 46307, writer2.ID, reader4.ID);
            library.bookManager.addBook(book1);
            library.bookManager.addBook(book2);
            library.bookManager.addBook(book3);
            library.bookManager.addBook(book4);
            library.bookManager.addBook(book5);
            library.bookManager.addBook(book6);

            // Sample loans
            library.loanManager.borrowBook(book1.ISBN, reader3.ID);
            library.loanManager.borrowBook(book2.ISBN, reader4.ID);

            Console.WriteLine("Login as:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Reader");
            Console.Write("Choose: ");
            string input = Console.ReadLine();
            bool isAdmin = input == "1";

            while (true)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Show Books");
                Console.WriteLine("2. Show Readers");
                Console.WriteLine("3. Show Writers");
                Console.WriteLine("4. Show Loans");

                if (isAdmin)
                {
                    Console.WriteLine("5. Register Reader");
                    Console.WriteLine("6. Add Book");
                    Console.WriteLine("7. Add Writer");
                    Console.WriteLine("8. Save JSON");
                    Console.WriteLine("9. Load JSON");
                }

                Console.WriteLine("0. Exit");
                Console.Write("Select: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        library.bookManager.showBooks();
                        break;
                    case "2":
                        library.readerManager.showReaderList();
                        break;
                    case "3":
                        library.writerManager.showWriters();
                        break;
                    case "4":
                        library.loanManager.showActiveLoans();
                        break;
                    case "5":
                        if (isAdmin)
                        {
                            Console.Write("Name: ");
                            string name = Console.ReadLine();
                            Console.Write("ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Is Premium (y/n): ");
                            string t = Console.ReadLine();
                            Reader r;
                            if (t.ToLower() == "y")
                            {
                                r = new PremiumReader(name, id);
                            }
                            else
                            {
                                r = new CasualReader(name, id);
                            }
                            library.readerManager.registerReader(r);
                        }
                        break;
                    case "6":
                        if (isAdmin)
                        {
                            Console.Write("Name: ");
                            string bname = Console.ReadLine();
                            Console.Write("ISBN: ");
                            int isbn = int.Parse(Console.ReadLine());
                            Console.Write("Writer ID: ");
                            int wid = int.Parse(Console.ReadLine());
                            Console.Write("Reader ID: ");
                            int rid = int.Parse(Console.ReadLine());
                            Book b = new Book(bname, isbn, wid, rid);
                            library.bookManager.addBook(b);
                        }
                        break;
                    case "7":
                        if (isAdmin)
                        {
                            Console.Write("Writer Name: ");
                            string wname = Console.ReadLine();
                            Console.Write("Writer ID: ");
                            int wid = int.Parse(Console.ReadLine());
                            library.writerManager.AddWriter(new Writer(wname, wid));
                        }
                        break;
                    case "8":
                        if (isAdmin)
                        {
                            library.readerManager.saveReaders();
                            library.writerManager.saveWriters();
                            library.bookManager.saveBooks();
                            library.loanManager.saveLoans();
                            Console.WriteLine("Saved.");
                        }
                        break;
                    case "9":
                        if (isAdmin)
                        {
                            library.readerManager.loadReaders();
                            library.writerManager.loadWriters();
                            library.bookManager.loadBooks();
                            library.loanManager.loadLoans();
                            Console.WriteLine("Loaded.");
                        }
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid.");
                        break;
                }
            }
        }
    }
}
