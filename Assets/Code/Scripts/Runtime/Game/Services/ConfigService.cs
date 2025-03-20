using Game.Models;
using Game.Infrastructure.Interfaces;
using Game.Services.Interfaces;

namespace Game.Services
{
    /// <summary>
    /// Реализация интерфейса <see cref="IConfigService"/>
    /// </summary>
    public class ConfigService : IConfigService
    {
        public GameConfig Config { get; }

        public ConfigService(IConfigLoader configLoader)
        {
            Config = configLoader.LoadConfig();
        }
    }
}