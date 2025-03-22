using Game.Models;
using R3;
using UnityEngine;

namespace Game.Controllers
{
    /// <summary>
    /// Котроллер куба
    /// </summary>
    public class BoxViewModel
    {
        private readonly BoxModel _model;

        public ReadOnlyReactiveProperty<int> Id { get; }

        public ReadOnlyReactiveProperty<Color> Color { get; }

        public BoxViewModel(BoxModel model)
        {
            _model = model;

            Id = new ReactiveProperty<int>(model.Id);
            Color = new ReactiveProperty<Color>(model.Color);
        }
    }
}