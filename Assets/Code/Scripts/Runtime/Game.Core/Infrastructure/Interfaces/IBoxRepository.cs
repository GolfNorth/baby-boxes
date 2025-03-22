using Game.Controllers;
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
        BoxViewModel GetCubeById(int id);

        /// <summary>
        /// Создает новый куб
        /// </summary>
        BoxViewModel CreateBox(Color color);
    }
}