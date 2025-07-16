using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace KonsolProjesi1
{
    public class ReaderManager
    {
        public List<PremiumReader> premiumReaders { get; }
        public List<CasualReader> casualReaders { get; }
        public ReaderManager()
        {
            this.premiumReaders = new List<PremiumReader>();
            this.casualReaders = new List<CasualReader>();
        }
        public void deleteReader(Reader reader)
        {
            if (reader is PremiumReader premium)
            {
                if (premiumReaders.Remove(premium))
                    Console.WriteLine("Premium reader removed.");
                else
                    Console.WriteLine("Premium reader not found.");
            }
            else if (reader is CasualReader casual)
            {
                if (casualReaders.Remove(casual))
                    Console.WriteLine("Casual reader removed.");
                else
                    Console.WriteLine("Casual reader not found.");
            }

        }
        public void registerReader(Reader reader)
        {
            if (reader is PremiumReader premium)
            {
                if (!premiumReaders.Contains(premium))
                {
                    premiumReaders.Add(premium);
                    Console.WriteLine("Premium reader registered.");
                }
                else
                {
                    Console.WriteLine("Premium reader already registered.");
                }
            }
            else if (reader is CasualReader casual)
            {
                if (!casualReaders.Contains(casual))
                {
                    casualReaders.Add(casual);
                    Console.WriteLine("Casual reader registered.");
                }
                else
                {
                    Console.WriteLine("Casual reader already registered.");
                }
            }
        }
        public void showReaderList()
        {
            Console.WriteLine("Premium readers:");
            foreach (var reader in premiumReaders)
            {
                Console.WriteLine(reader.name);
            }

            Console.WriteLine("Casual readers:");
            foreach (var reader in casualReaders)
            {
                Console.WriteLine(reader.name);
            }
        }

        
        public void saveReaders()
        {
            File.WriteAllText("premiumReaders.json",
                JsonSerializer.Serialize(premiumReaders, new JsonSerializerOptions { WriteIndented = true }));

            File.WriteAllText("casualReaders.json",
                JsonSerializer.Serialize(casualReaders, new JsonSerializerOptions { WriteIndented = true }));
        }
        public void loadReaders()
        {
            premiumReaders.Clear();
            casualReaders.Clear();

            if (File.Exists("premiumReaders.json"))
            {
                string json = File.ReadAllText("premiumReaders.json");
                var loaded = JsonSerializer.Deserialize<List<PremiumReader>>(json);
                if (loaded != null)
                    premiumReaders.AddRange(loaded);
            }

            if (File.Exists("casualReaders.json"))
            {
                string json = File.ReadAllText("casualReaders.json");
                var loaded = JsonSerializer.Deserialize<List<CasualReader>>(json);
                if (loaded != null)
                    casualReaders.AddRange(loaded);
            }
        }

    }
}
