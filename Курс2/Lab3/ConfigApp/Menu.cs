using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigApp
{
    class Menu
    {
        public FileSystemWatcher fileSystemWatcher;
        public Paths paths { get; set; }
        public Archivator archieve { get; set; }
        public Cipher cipher { get; set; }

        private string fileText;

        private void ReadConfigs()
        {
            try
            {
                var appPath = AppDomain.CurrentDomain.BaseDirectory;
                var manager = new ConfigManager();

                paths = manager.GetOption<Paths>(appPath + "config.xml");
                archieve = manager.GetOption<Archivator>(appPath + "config.xml");
                cipher = manager.GetOption<Cipher>(appPath + "appSettings.json");
            }
            catch (Exception trouble)
            {
                using (var writer = new StreamWriter(@"E:\TargetDirectory\Errors.txt", true))
                {
                    writer.WriteLine(trouble.Message);
                }
            }
        }

        public void Start()
        {
            ReadConfigs();
            CheckChanges();
        }

        public void CheckChanges()
        {
            fileSystemWatcher = new FileSystemWatcher(paths.Source)
            {
                EnableRaisingEvents = true,
                IncludeSubdirectories = true
            };

            fileSystemWatcher.Created += DirectoryChanged;
            fileSystemWatcher.Deleted += DirectoryChanged;
            fileSystemWatcher.Renamed += FileRenamed;
            fileSystemWatcher.Changed += DirectoryChanged;
        }

        private void FileRenamed(object sender, RenamedEventArgs e)
        {
            EncryptFileText(e.FullPath);

            GetArchiveFile(e.FullPath);

            var msg = $"{e.ChangeType} - {e.FullPath} - {DateTime.Now}{Environment.NewLine}";
            File.AppendAllText(paths.Logger, msg);
        }

        private void DirectoryChanged(object sender, FileSystemEventArgs e)
        {
            var msg = $"{e.ChangeType} - {e.FullPath} - {DateTime.Now}{Environment.NewLine}";
            File.AppendAllText(paths.Logger, msg);
        }

        private void GetArchiveFile(string path)
        {
            try
            {
                var compressFile = Path.ChangeExtension(path, archieve.Extension); // E:\SourceDirectory\text.rar

                archieve.Archivate(path, compressFile);
                File.Delete(path);

                File.Copy(compressFile, Path.GetFileName(compressFile));
                archieve.Dearchivate(Path.GetFileName(compressFile), Path.ChangeExtension(targetPath, ".txt"));
                DecryptFileText(Path.ChangeExtension(Path.GetFileName(compressFile), ".txt"));
                File.Delete(Path.GetFileName(compressFile));
            }
            catch (Exception trouble)
            {
                using (var writer = new StreamWriter(paths.Logger, true))
                {
                    writer.WriteLine(trouble.Message);
                }
            }
        }

        private void EncryptFileText(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                fileText = reader.ReadToEnd();
            }

            using (var writer = new StreamWriter(filePath))
            {
                fileText = cipher.Crypt(fileText, cipher.Key);
                writer.WriteLine(fileText);
            }
        }

        private void DecryptFileText(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                fileText = cipher.Decrypt(fileText, cipher.Key);
                writer.WriteLine(fileText);
            }
        }
    }
}