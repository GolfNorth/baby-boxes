using Code.Services.Interfaces;
using Game.Data;
using Game.Infrastructure.Interfaces;

namespace Code.Services
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