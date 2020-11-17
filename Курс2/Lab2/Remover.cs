using System.IO;

namespace WindowsService1
{
    class Remover
    {
        public FileInfo Infa { get; set; }

        public string Source { get; set; }

        public string Target { get; set; }

        public string NameOfFile { get; set; }

        public Remover(string source, string target, string nameoffile)
        {
            this.Source = source;
            this.Target = target;
            this.NameOfFile = nameoffile;
            this.Infa = new FileInfo(source + nameoffile);
        }

        public void addFile()
        {
            string path = this.CreateFolders();
            string newNameOfFile = $"\\Sales_{Infa.CreationTime.Year}_{Infa.CreationTime.Month}" +
                $"_{Infa.CreationTime.Day}_{Infa.CreationTime.Hour}" +
                $"_{Infa.CreationTime.Minute}_{Infa.CreationTime.Second}";
            string fullPath = path + newNameOfFile;
            File.Copy(Source + NameOfFile, fullPath, true);
            File.Delete(Source + NameOfFile);
            (string cryptPath, string cryptName) = DeCrypt.CryptFile(fullPath);
            File.Delete(fullPath);
            string compressSource = Compressor.Compress(cryptPath, cryptName);
            Compressor.Decompress(compressSource, cryptName);
        }


        public string CreateFolders()
        {
            string year = Infa.CreationTime.Year.ToString();
            string month = Infa.CreationTime.Month.ToString();
            string day = Infa.CreationTime.Day.ToString();
            string path = $"{Target}\\{year}\\{month}\\{day}";
            Directory.CreateDirectory(path);
            Directory.CreateDirectory("C:\\Target_Text\\Archive");
            return path;
        }
    }
}
