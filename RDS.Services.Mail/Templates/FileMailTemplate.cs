using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;

namespace RDS.Services.Mail
{
    public class FileMailTemplate : IFileMailTemplate 
    {
        IFileSystem _fileSystem;
        private string _body;
        public string Body { get { return _body ?? ReadFile(); } set { _body = value; } }
        private string _path;
        public string Path { get { return _path; } set { _path = ValidatePath(value); } }
        public bool StoreInMemory { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public bool IsBodyHtml { get; set; }

        public FileMailTemplate()
        {
            _fileSystem = new FileSystem();
        }

        internal FileMailTemplate(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        private string ReadFile()
        {
            string output = null;
            try
            {
                output = _fileSystem.File.ReadAllText(Path);
            }
            catch { }
            if (StoreInMemory)
                return _body = output;

            return output;
        }

        private string ValidatePath(string path)
        {
            string defaultPath = GetDefaultPath(path);
            if (_fileSystem.File.Exists(defaultPath))
                return defaultPath;

            string currentDirectoryPath = GetCurrentDirectoryPath(path);
            if (_fileSystem.File.Exists(currentDirectoryPath))
                return currentDirectoryPath;

            if (_fileSystem.File.Exists(path))
                return path;

            throw new ArgumentException($"File not found {Environment.CurrentDirectory} {path}.", nameof(path));
        }

        private string GetDefaultPath(string path)
        {
            return _fileSystem.Path.Combine(Environment.CurrentDirectory, "wwwroot\\templates\\mail\\", path);
        }

        private string GetCurrentDirectoryPath(string path)
        {
            return _fileSystem.Path.Combine(Environment.CurrentDirectory, path);
        }
    }
}
