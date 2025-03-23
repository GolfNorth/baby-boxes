using System;
using System.Collections.Generic;
using Game.Infrastructure.Interfaces;
using Game.ViewModels;
using Game.Models;
using Game.Services.Interfaces;
using UnityEngine;

namespace Game.Infrastructure
{
    /// <summary>
    /// Реализация интерфейса <see cref="IBoxRepository"/>
    /// </summary>
    public class BoxRepository : IBoxRepository
    {
        private int _nextId;

        private readonly Func<int, Color, BoxModel> _modelFactory;

        private readonly ISaveService _saveService;

        private readonly Dictionary<int, BoxViewModel> _viewModels = new();

        public BoxRepository(Func<int, Color, BoxModel> modelFactory, ISaveService saveService)
        {
            _modelFactory = modelFactory;
            _saveService = saveService;
        }

        public IEnumerable<BoxViewModel> Boxes => _viewModels.Values;

        public BoxViewModel GetBoxById(int id)
        {
            return _viewModels.GetValueOrDefault(id);
        }

        public BoxViewModel AddBox(Color color)
        {
            var model = _modelFactory.Invoke(_nextId, color);
            var viewModel = new BoxViewModel(model);

            _viewModels.Add(_nextId++, viewModel);

            return viewModel;
        }

        public void RemoveBox(int id)
        {
            _viewModels.Remove(id);
        }
    }
}