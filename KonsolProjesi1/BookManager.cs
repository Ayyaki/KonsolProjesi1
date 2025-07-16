using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace KonsolProjesi1
{
    public class BookManager
    {
        public List<Book> books { get; private set; }
        public BookManager()
        {

            books = new List<Book>();
        }

        public void addBook(Book book)
        {
            if (!books.Contains(book))
            {
                books.Add(book);
                Console.WriteLine("Book added.");
            }
            else
            {
                Console.WriteLine("Book already exists.");
            }
        }
        public void removeBook(Book book)
        {
            if (books.Contains(book))
            {
                books.Remove(book);
                Console.WriteLine("The book is removed.");
            }
            else { Console.WriteLine("{0} is not in the library.", book.name); }
        }

        public void searchBook(int ISBN)
        {
            foreach (var book in books)
            {
                if (book.ISBN == ISBN)
                {

                    Console.WriteLine("Here is the book: {0}", book.name);
                    
                    return;
                }
            }
            Console.WriteLine("No such book with that ISBN number.");
          
        }
        public void showBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
                return;
            }
            foreach (var pair in Library.Instance.writerManager.writerMap)
            {
                int id = pair.Key;
                Writer writer = pair.Value;

                Console.WriteLine($"Writer ID: {id}, Name: {writer.name}");
            }
            foreach (var book in books)
            {
                if (Library.Instance.writerManager.writerMap.TryGetValue(book.writerID, out Writer writer))
                {
                    
                    Console.WriteLine($"Name: {book.name}, ISBN: {book.ISBN}, Writer: {writer.name}");
                }
                else
                {
                    Console.WriteLine(book.writerID);
                    Console.WriteLine($"Name: {book.name}, ISBN: {book.ISBN}, Writer: [Unknown]");
                }
            }
        }
        public void updateBookOwner(Book book, Reader newOwner)
        {
            book.ownerID = newOwner.ID;
            newOwner.ownedBooks.Add(book);
            Console.WriteLine("Owner has been updated.");
        }
        public void saveBooks()
        {
            string json = JsonSerializer.Serialize(books, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("books.json", json);
        }
        public void loadBooks()
        {
            if (File.Exists("books.json"))
            {
                string json = File.ReadAllText("books.json");
                var loadedBooks = JsonSerializer.Deserialize<List<Book>>(json);

                if (loadedBooks != null)
                {
                    books.Clear();
                    books.AddRange(loadedBooks);
                }
            }
        }
    }
}
