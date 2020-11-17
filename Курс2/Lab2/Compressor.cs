﻿using System.IO;
using System.IO.Compression;

namespace WindowsService1
{
    class Compressor
    {
        const string targetPath = "C:\\Target_Text\\Archive";
        public static string Compress(string FileSource, string FileName)
        {
            string SourceCopy = FileSource;

            FileStream sourceStream = new FileStream(FileSource, FileMode.OpenOrCreate);

            using (FileStream targetStream = File.Create(FileSource.Remove(FileSource.LastIndexOf(".crypt")) + ".gz"))
            {
                using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                {
                    sourceStream.CopyTo(compressionStream); 
                }
            }

            return FileSource.Remove(FileSource.LastIndexOf(".crypt")) + ".gz";
        }


        public static void Decompress(string compressedSource, string FileName)
        {
            FileStream sourceStream = new FileStream(compressedSource, FileMode.OpenOrCreate);

            string targetSource = (compressedSource.Remove(compressedSource.LastIndexOf(".gz")) + ".txt").Insert(15, "Archive");
            File.WriteAllText("C:\\Games\\Textos.txt", targetSource);

            string newName = "\\" + FileName.Remove(FileName.LastIndexOf(".crypt")) + ".txt";
            File.WriteAllText("C:\\Games\\Textossss.txt", newName);

            string directory = targetSource.Remove(targetSource.LastIndexOf(newName));

            Directory.CreateDirectory(directory);

            using (FileStream targetStream = File.Create(targetSource))
            {
                // поток разархивации
                using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                {
                    decompressionStream.CopyTo(targetStream);
                }
            }

            DeCrypt.Decrypt(targetSource);
        }
    }
}
