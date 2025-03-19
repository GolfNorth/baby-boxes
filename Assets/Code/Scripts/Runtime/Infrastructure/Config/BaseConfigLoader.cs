using Game.Data;
using Game.Infrastructure.Interfaces;
using UnityEngine;

namespace Game.Infrastructure
{
    /// <summary>
    /// Базовый загрузчик игровой конфигурации
    /// </summary>
    public abstract class BaseConfigLoader : ScriptableObject, IConfigLoader
    {
        public abstract GameConfig LoadConfig();
    }
}