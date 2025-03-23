using UnityEngine;

namespace Game.Data
{
    /// <summary>
    /// Объект для создания игровых данных
    /// </summary>
    [CreateAssetMenu(menuName = "Boxes/GameConfigData", fileName = "GameConfigData", order = 0)]
    public class GameConfigData : ScriptableObject
    {
        /// <summary>
        /// Размер куба
        /// </summary>
        [field: SerializeField]
        public Vector2 Size { get; private set; }

        /// <summary>
        /// Игровые данные
        /// </summary>
        [field: SerializeField]
        public Color[] Colors { get; private set; }
    }
}