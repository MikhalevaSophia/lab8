using System;
using System.IO.Compression;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь для искомого файла");
            string search = Console.ReadLine();

            Console.WriteLine("Введите имя документа");
            string target = Console.ReadLine();

            string[] files = Directory.GetFiles(search, target, SearchOption.AllDirectories);

            if (files.Length == 0)
            {
                Console.WriteLine("Файл не найден");
            }
            else
            {
                foreach(string FilePath in files){
                    Console.WriteLine($"Найден файл : {FilePath}");
                    using (FileStream fileStream = File.OpenRead(FilePath))
                    {
                        using(StreamReader reader = new StreamReader(fileStream))
                        {
                            string filecontent = reader.ReadToEnd();
                            Console.WriteLine($"Содержимое файла : \n{filecontent}");
                        }
                    }
                    string compressedpath = Path.ChangeExtension(FilePath, ".gz");
                    using(FileStream fileStream = File.OpenRead(FilePath))
                    {
                        using(FileStream Steam = File.Create(compressedpath))
                        {
                            using (GZipStream compressedSteam = new GZipStream(Steam, CompressionMode.Compress))
                            {
                                fileStream.CopyTo(compressedSteam);
                                Console.WriteLine($"Файл сжат : {compressedSteam}");
                            }
                        }
                    }
                }
            }
        }
    }
}
