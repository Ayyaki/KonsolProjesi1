using System;
using System.Collections.Generic;

namespace KonsolProjesi1
{
    public class Writer:ComponentsOfLibrary
    {
        public int ID { get; private set; }
        public String name { get; private set; }
        public List<Book> writtenBooks { get; private set; }
        public Writer(String name,int ID)
        {
            this.ID = ID;
            this.name = name;
            this.writtenBooks = new List<Book>();
        }
        public void showWrittenBooks()
        {
            Console.WriteLine("Here are the books of {0}: ", name);
            foreach (var book in writtenBooks)
            {
                Console.WriteLine(book.name);
            }
        }


    }
}
