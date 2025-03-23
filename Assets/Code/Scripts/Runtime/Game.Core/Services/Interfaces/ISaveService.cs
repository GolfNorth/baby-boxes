namespace Game.Services.Interfaces
{
    /// <summary>
    /// Сервис сохранения данных
    /// </summary>
    public interface ISaveService
    {
        void Set(string data);
        string Get();
        void Save();
    }
}