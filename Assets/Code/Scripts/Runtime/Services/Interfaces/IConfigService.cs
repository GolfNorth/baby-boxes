using Game.Data;

namespace Code.Services.Interfaces
{
    /// <summary>
    /// Сервис доступа к игровой конфигурации
    /// </summary>
    public interface IConfigService
    {
        GameConfig Config { get; }
    }
}