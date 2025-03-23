using System;
using Game.Enums;
using Game.Events;
using Game.Infrastructure.Interfaces;
using Game.Models;
using Game.SDK.Infrastructure.Interfaces;
using Game.Services.Interfaces;
using Game.ViewModels;
using Newtonsoft.Json;
using UnityEngine;
using VContainer.Unity;

namespace Game.Infrastructure
{
    /// <summary>
    /// Система сохранения 
    /// </summary>
    public class SaveSystem : IStartable
    {
        private readonly ISaveService _saveService;
        private readonly TowerViewModel _towerViewModel;
        private readonly IBoxRepository _boxRepository;


        public SaveSystem(ISaveService saveService, ITowerRepository towerRepository, IBoxRepository boxRepository,
            IEventBus eventBus)
        {
            _saveService = saveService;
            _boxRepository = boxRepository;
            _towerViewModel = towerRepository.GetTower();

            eventBus.Subscribe<ApplicationQuitEvent>(OnApplicationQuit);
        }

        private void OnApplicationQuit(ApplicationQuitEvent _)
        {
            var mementos = new BoxMemento[_towerViewModel.Boxes.Count];

            for (var i = 0; i < _towerViewModel.Boxes.Count; i++)
            {
                var viewModel = _towerViewModel.Boxes[i];
                var memento = new BoxMemento(viewModel.Color.CurrentValue, viewModel.Position.Value);

                mementos[i] = memento;
            }

            var json = JsonConvert.SerializeObject(mementos);

            _saveService.Set(json);
            _saveService.Save();
        }

        public void Start()
        {
            var json = _saveService.Get();

            if (string.IsNullOrEmpty(json))
                return;

            try
            {
                var mementos = JsonConvert.DeserializeObject<BoxMemento[]>(json);

                foreach (var memento in mementos)
                {
                    var vm = _boxRepository.AddBox(memento.Color);
                    vm.Position.Value = new Vector2(memento.X, memento.Y);
                    vm.State.Value = BoxState.Placed;
                }
            }
            catch (Exception _)
            {
                // ignored
            }
        }
    }
}