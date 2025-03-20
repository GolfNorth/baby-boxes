using System.Collections.Generic;
using Game.Factories.Interfaces;
using Game.Models;
using Game.Systems.Interfaces;
using UnityEngine;

namespace Game.Infrastructure
{
    /// <summary>
    /// Реализация интерфейса <see cref="IBoxRepository"/>
    /// </summary>
    public class BoxRepository : IBoxRepository
    {
        private int _nextId;

        private readonly IBoxFactory _boxFactory;

        private readonly Dictionary<int, BoxInstance> _boxInstances = new();

        public BoxRepository(IBoxFactory boxFactory)
        {
            _boxFactory = boxFactory;
        }

        public BoxInstance GetCubeById(int id)
        {
            return _boxInstances.GetValueOrDefault(id);
        }

        public BoxInstance CreateBox(Color color)
        {
            var box = _boxFactory.CreateBox(_nextId, color);

            _boxInstances.Add(_nextId++, box);

            return box;
        }
    }
}