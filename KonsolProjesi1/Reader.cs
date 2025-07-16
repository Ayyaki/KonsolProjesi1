using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace KonsolProjesi1
{
    public abstract class Reader:ComponentsOfLibrary
    {
        public int ID { get; protected set; }
        public string json { get; protected set; }
        public String name { get; protected set; }
        public List<Book> ownedBooks { get; protected set; }
        public int maxBorrowLimit { get; protected set; }
        
        public Reader(String name,int ID)
        {
            this.ID = ID;
            this.name = name;
            this.ownedBooks =new List<Book>();
        }
    }
    public class PremiumReader : Reader
    {
        public PremiumReader(string name, int ID) : base(name, ID)
        {
            maxBorrowLimit = 10;

        }
        public PremiumReader() : base("", 0)
        {
            maxBorrowLimit = 10;
            
        }


    }
    public class CasualReader : Reader
    {
        public CasualReader(string name, int ID) : base(name, ID)
        {
            maxBorrowLimit = 3;
        }
        public CasualReader() : base("", 0)
        {
            maxBorrowLimit = 3;
        }
    }
}
