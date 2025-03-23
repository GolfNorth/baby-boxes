using System;
using DG.Tweening;
using UnityEngine;

namespace Game.Presentation.Components
{
    [Serializable]
    public abstract class TweenBase
    {
        public abstract void Play(RectTransform rect, Vector2 destination, TweenCallback callback = null);
    }
}