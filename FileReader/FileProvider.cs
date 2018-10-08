namespace FileReader
{
    using System.IO;
    using System.Linq;

    public class FileProvider : IFileProvider
    {

        public bool Exists(string name)
        {
            string file = Directory.GetFiles(ApplicationSettings.SharedDirectory, name, SearchOption.TopDirectoryOnly)
                .FirstOrDefault();
            return file != null;
        }

        public FileStream Open(string name)
        {
            return File.Open(GetFilePath(name),
                FileMode.Open, FileAccess.Read);
        }

        public long GetLength(string name)
        {
            return new FileInfo(GetFilePath(name)).Length;
        }

        private string GetFilePath(string name)
        {
            return Path.Combine(ApplicationSettings.SharedDirectory, name);
        }
    }
}