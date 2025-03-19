using Game.Data;

namespace Game.Infrastructure.Interfaces
{
    /// <summary>
    /// Интерфейс загрузки игровой конфигурации
    /// </summary>
    public interface IConfigLoader
    {
        GameConfig LoadConfig();
    }
}