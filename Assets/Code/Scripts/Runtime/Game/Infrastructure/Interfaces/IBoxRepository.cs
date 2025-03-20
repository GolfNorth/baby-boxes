using Game.Models;
using UnityEngine;

namespace Game.Systems.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория кубов
    /// </summary>
    public interface IBoxRepository
    {
        /// <summary>
        /// Получить инстанс куба по его идентификатору
        /// </summary>
        BoxInstance GetCubeById(int id);

        /// <summary>
        /// Создает новый куб
        /// </summary>
        BoxInstance CreateBox(Color color);
    }
}