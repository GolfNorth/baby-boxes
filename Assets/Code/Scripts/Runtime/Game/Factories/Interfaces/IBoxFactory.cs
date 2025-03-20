using Game.Models;
using UnityEngine;

namespace Game.Factories.Interfaces
{
    /// <summary>
    /// Фабрика создания кубов
    /// </summary>
    public interface IBoxFactory
    {
        BoxInstance CreateBox(int id, Color color);
    }
}