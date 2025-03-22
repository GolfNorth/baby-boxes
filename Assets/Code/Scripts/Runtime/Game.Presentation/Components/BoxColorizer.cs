﻿using Game.Presentation.Views;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Presentation.Components
{
    /// <summary>
    /// Устанавливает цвет куба
    /// </summary>
    public class BoxColorizer : MonoBehaviour
    {
        [SerializeField]
        private BoxView view;

        [SerializeField]
        private Image image;

        private void Awake()
        {
            view.Color.Subscribe(OnColorChanged);
        }

        private void OnColorChanged(Color color)
        {
            image.color = color;
        }
    }
}