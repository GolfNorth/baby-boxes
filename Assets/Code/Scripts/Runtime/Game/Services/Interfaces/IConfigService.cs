using Game.Models;

namespace Game.Services.Interfaces
{
    /// <summary>
    /// Сервис доступа к игровой конфигурации
    /// </summary>
    public interface IConfigService
    {
        GameConfig Config { get; }
    }
}