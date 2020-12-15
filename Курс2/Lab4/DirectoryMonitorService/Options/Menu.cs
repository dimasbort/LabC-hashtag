using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using ConfigurationManager;
using DataAccessLayer.Repositories;
using DBModels.Entities;
using ServiceLayer.Services;

namespace DirectoryMonitorService
{
    class Menu
    {
        public FileSystemWatcher fileSystemWatcher;
        public PathOption pathOption { get; set; }
        public Logs logs { get; set; }
        public ArchiveOption archieveOption { get; set; }
        public CipherOption cipherOption { get; set; }

        private string fileText;

        private void SetOptions()
        {
            try
            {
                var appPath = AppDomain.CurrentDomain.BaseDirectory;
                var manager = new ConfigManager();

                pathOption = manager.GetOption<PathOption>(appPath + "config.xml");
                logs = manager.GetOption<Logs>(appPath + "appSettings.json");
                archieveOption = manager.GetOption<ArchiveOption>(appPath + "config.xml");
                cipherOption = manager.GetOption<CipherOption>(appPath + "appSettings.json");
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
            SetOptions();

            Monitoring();
        }

        public void Monitoring()
        {
            fileSystemWatcher = new FileSystemWatcher(pathOption.SourceDirectory)
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
            File.AppendAllText(logs.Log, msg);
        }

        private void DirectoryChanged(object sender, FileSystemEventArgs e)
        {
            var msg = $"{e.ChangeType} - {e.FullPath} - {DateTime.Now}{Environment.NewLine}";
            File.AppendAllText(logs.Log, msg);
        }

        private void GetArchiveFile(string path)
        {
            try
            {
                var compressFile = Path.ChangeExtension(path, archieveOption.Extension); // E:\SourceDirectory\text.rar

                archieveOption.Compress(path, compressFile);
                File.Delete(path);

                var targetPath = CreateDataArchieve() + Path.GetFileName(compressFile);
                File.Copy(compressFile, targetPath);
                archieveOption.Decompress(targetPath, Path.ChangeExtension(targetPath, ".xml"));
                DecryptFileText(Path.ChangeExtension(targetPath, ".xml"));
                File.Delete(targetPath);
            }
            catch (Exception trouble)
            {
                using (var writer = new StreamWriter(logs.Log, true))
                {
                    writer.WriteLine(trouble.Message);
                }
            }
        }

        private string CreateDataArchieve()
        {
            DateTime date = DateTime.Now;
            string filepath = pathOption.TargetDirectory + "\\archive " + date.ToString("D");

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            return filepath + "\\";
        }

        private void EncryptFileText(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                fileText = reader.ReadToEnd();
            }

            using (var writer = new StreamWriter(filePath))
            {
                fileText = cipherOption.Encrypt(fileText, cipherOption.Key);
                writer.WriteLine(fileText);
            }
        }

        private void DecryptFileText(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                fileText = cipherOption.Decrypt(fileText, cipherOption.Key);
                writer.WriteLine(fileText);
            }
        }
    }
}