using Game.Enums;
using Game.Models;
using R3;
using UnityEngine;

namespace Game.ViewModels
{
    /// <summary>
    /// Котроллер куба
    /// </summary>
    public class BoxViewModel
    {
        private readonly BoxModel _model;

        public ReadOnlyReactiveProperty<int> Id { get; }

        public ReadOnlyReactiveProperty<Color> Color { get; }

        public ReactiveProperty<BoxState> State { get; } = new();

        public ReactiveProperty<Vector2> Position { get; } = new();

        public BoxViewModel(BoxModel model)
        {
            _model = model;

            Id = new ReactiveProperty<int>(model.Id);
            Color = new ReactiveProperty<Color>(model.Color);
            State.Value = model.State;
            Position.Value = model.Position;

            State.Subscribe(OnStateChanged);
            Position.Subscribe(OnPositionChanged);
        }

        private void OnStateChanged(BoxState state)
        {
            _model.State = state;
        }

        private void OnPositionChanged(Vector2 position)
        {
            _model.Position = position;
        }
    }
}