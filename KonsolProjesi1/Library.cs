using System;
using System.Collections.Generic;


namespace KonsolProjesi1
{
    public class Library
    {
        private static Library _instance;
        public static Library Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Library("Suna Kıraç Library");
                }
                return _instance;
            }
        }
        public string name { get; }
        public LoanManager loanManager { get; }
        public ReaderManager readerManager { get; }
        public BookManager bookManager { get; }
        public WriterManager writerManager { get; }

        public Library(String name)
        {

            this.name = name;
            loanManager = new LoanManager();
            readerManager = new ReaderManager();
            bookManager = new BookManager();
            writerManager = new WriterManager();
        }
        public void SaveAll()
        {
            readerManager.saveReaders();
            bookManager.saveBooks();
            writerManager.saveWriters();
            loanManager.saveLoans();
        }

        public void LoadAll()
        {
            readerManager.loadReaders();
            bookManager.loadBooks();
            writerManager.loadWriters();
            loanManager.loadLoans();
        }

        

        
    }
}
