using Game.Models;
using ObservableCollections;
using R3;
using UnityEngine;

namespace Game.ViewModels
{
    public class TowerViewModel
    {
        private readonly TowerModel _model;

        private readonly ObservableList<int> _boxIds;

        public IReadOnlyObservableList<int> BoxIds => _boxIds;

        public ReactiveProperty<Vector2> Size { get; } = new();

        public TowerViewModel(TowerModel model)
        {
            _model = model;
            _boxIds = new ObservableList<int>();

            Size.Subscribe(x => _model.Size = x);
        }

        /// <summary>
        /// Добавить куб в башню
        /// </summary>
        public void AddBox(int id)
        {
            _boxIds.Add(id);
            _model.BoxIds.Add(id);
        }

        /// <summary>
        /// Удалить куб из башни
        /// </summary>
        public void RemoveBox(int id)
        {
            _boxIds.Remove(id);
            _model.BoxIds.Remove(id);
        }
    }
}