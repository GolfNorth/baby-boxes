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
        private readonly GameConfig _config;

        public ConfigService(IConfigLoader configLoader)
        {
            _config = configLoader.LoadConfig();
        }

        public GameConfig GetConfig()
        {
            return _config;
        }
    }
}