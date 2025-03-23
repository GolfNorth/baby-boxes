using System;
using DG.Tweening;
using UnityEngine;

namespace Game.Presentation.Components
{
    [Serializable]
    public class TweenScale : TweenBase
    {
        [SerializeField]
        private Vector3 endValue;

        [SerializeField]
        private float duration;

        public override void Play(RectTransform rect, Vector2 destination, TweenCallback callback = null)
        {
            rect.DOScale(endValue, duration).OnComplete(callback);
        }
    }
}