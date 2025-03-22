using System.Collections.Generic;
using Game.Controllers;
using UnityEngine;

namespace Game.Systems.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория кубов
    /// </summary>
    public interface IBoxRepository
    {
        IEnumerable<BoxViewModel> Boxes { get; }
        
        /// <summary>
        /// Получить инстанс куба по его идентификатору
        /// </summary>
        BoxViewModel GetBoxById(int id);

        /// <summary>
        /// Создает новый куб
        /// </summary>
        BoxViewModel AddBox(Color color);

        /// <summary>
        /// Удаляет куб
        /// </summary>
        void RemoveBox(int id);
    }
}