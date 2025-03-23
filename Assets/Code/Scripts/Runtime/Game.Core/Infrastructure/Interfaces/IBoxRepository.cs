using System.Collections.Generic;
using Game.ViewModels;
using UnityEngine;

namespace Game.Infrastructure.Interfaces
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