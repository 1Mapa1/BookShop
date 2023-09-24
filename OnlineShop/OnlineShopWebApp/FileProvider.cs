using OnlineShopWebApp.Interfaces;
using System.IO;
using System.Text;

namespace OnlineShopWebApp
{
    public class FileProvider : IFileProvider
    {
        public void Rewriting(string jsonData, string fileName)
        {
            var writer = new StreamWriter(fileName, false, Encoding.UTF8);
            writer.WriteLine(jsonData);
            writer.Close();
        }
        public void Save(string jsonData, string fileName)
        {
            var writer = new StreamWriter(fileName, true, Encoding.UTF8);
            writer.WriteLine(jsonData);
            writer.Close();
        }
        public bool Exists(string fileName)
        {
            return File.Exists(fileName);
        }

        public string GetData(string fileName)
        {
            var reader = new StreamReader(fileName, Encoding.UTF8);
            string value = reader.ReadToEnd();
            reader.Close();
            return value;
        }
    }
}
