using System.Collections.Generic;
using Game.Infrastructure;
using Game.Infrastructure.Interfaces;
using Game.Models;
using ObservableCollections;
using R3;
using UnityEngine;

namespace Game.ViewModels
{
    public class TowerViewModel
    {
        private readonly TowerModel _model;

        private readonly IBoxRepository _boxRepository;

        private readonly ObservableList<BoxViewModel> _boxes;

        public IReadOnlyObservableList<BoxViewModel> Boxes => _boxes;

        public ReactiveProperty<Vector2> Size { get; } = new();

        public TowerViewModel(TowerModel model, IBoxRepository boxRepository)
        {
            _model = model;
            _boxRepository = boxRepository;
            _boxes = new ObservableList<BoxViewModel>();

            Size.Subscribe(x => _model.Size = x);
        }

        /// <summary>
        /// Добавить куб в башню
        /// </summary>
        public void AddBox(int id)
        {
            var box = _boxRepository.GetBoxById(id);

            _boxes.Add(box);
            _model.BoxIds.Add(id);

            _boxes.Sort(new BoxComparerByPosition());
        }

        /// <summary>
        /// Удалить куб из башни
        /// </summary>
        public void RemoveBox(int id)
        {
            var box = _boxRepository.GetBoxById(id);

            _boxes.Remove(box);
            _model.BoxIds.Remove(id);

            _boxes.Sort(new BoxComparerByPosition());
        }
    }
}