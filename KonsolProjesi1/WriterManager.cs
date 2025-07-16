using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace KonsolProjesi1
{
    public class WriterManager
    {
        public Dictionary<int, Writer> writerMap { get; private set; }
        public List<Writer> writers { get; private set; }
        public WriterManager()
        {
            this.writers = new List<Writer>();
            writerMap = new Dictionary<int, Writer>();
        }
        public void AddWriter(Writer writer)
        {
            if (!writerMap.ContainsKey(writer.ID))
            {
                writers.Add(writer);
                writerMap[writer.ID] = writer;
                Console.WriteLine("Writer added.");
            }
            else
            {
                Console.WriteLine("Writer with this ID already exists.");
            }
        }
        public void writeBook(Writer writer, Book book)
        {
            writer.writtenBooks.Add(book);
        }
        
        public void showWriters()
        {
            Console.WriteLine("Here are the writers:");
            foreach (var writer in writers)
            {
                
                Console.WriteLine(writer.name);
            }
        }
        public void saveWriters()
        {
            string json = JsonSerializer.Serialize(writers, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("writers.json", json);
        }
        public void loadWriters()
        {
            if (File.Exists("writers.json"))
            {
                string json = File.ReadAllText("writers.json");
                var loadedWriters = JsonSerializer.Deserialize<List<Writer>>(json);

                if (loadedWriters != null)
                {
                    writers.Clear();
                    writerMap.Clear();

                    foreach (var writer in loadedWriters)
                    {
                        writers.Add(writer);
                        writerMap[writer.ID] = writer;
                    }

                    Console.WriteLine("Writers loaded successfully.");
                }
            }
        }

    }
}
