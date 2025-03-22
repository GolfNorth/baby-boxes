﻿using System;
using System.Collections.Generic;
using Game.Controllers;
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

        private readonly Func<int, Color, BoxModel> _modelFactory;

        private readonly Dictionary<int, BoxViewModel> _viewModels = new();

        public BoxRepository(Func<int, Color, BoxModel> modelFactory)
        {
            _modelFactory = modelFactory;
        }

        public BoxViewModel GetCubeById(int id)
        {
            return _viewModels.GetValueOrDefault(id);
        }

        public BoxViewModel CreateBox(Color color)
        {
            var model = _modelFactory.Invoke(_nextId, color);
            var viewModel = new BoxViewModel(model);

            _viewModels.Add(_nextId++, viewModel);

            return viewModel;
        }
    }
}