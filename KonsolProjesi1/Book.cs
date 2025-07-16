using System;
namespace KonsolProjesi1
{
    public class Book:ComponentsOfLibrary
    {

        public String name { get; private set; }
        public int ownerID { get; set; }
        public int writerID { get; private set; }
        public int ISBN { get; private set; }
        public Book() { }

        public Book(string name, int ISBN, int writerID, int ownerID)
        {
            this.name = name;
            this.writerID = writerID;
            this.ownerID = ownerID;
            this.ISBN = ISBN;
        }

    }
}
