using Code.Models;
using Game.Data;
using UnityEngine;

namespace Game.Infrastructure
{
    /// <summary>
    /// Загрузчик конфигурации из <see cref="GameConfigData"/>
    /// </summary>
    [CreateAssetMenu(menuName = "Boxes/ScriptableObjectConfigLoader", fileName = "ScriptableObjectConfigLoader", order = 0)]
    public class ScriptableObjectConfigLoader : BaseConfigLoader
    {
        [SerializeField, Tooltip("Данные игровой конфигурации")]
        private GameConfigData configData;

        public override GameConfig LoadConfig()
        {
            return new GameConfigBuilder()
                .SetBoxColors(configData.Colors)
                .Build();
        }
    }
}