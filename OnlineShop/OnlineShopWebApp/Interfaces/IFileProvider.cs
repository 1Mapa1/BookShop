namespace OnlineShopWebApp.Interfaces
{
    public interface IFileProvider
    {
        void Rewriting(string jsonData, string fileName);
        void Save(string jsonData, string fileName);
        bool Exists(string fileName);
        string GetData(string fileName);
    }
}
