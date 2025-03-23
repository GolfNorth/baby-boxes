using System;
using DG.Tweening;
using UnityEngine;

namespace Game.Presentation.Components
{
    [Serializable]
    public class TweenPunch : TweenBase
    {
        [SerializeField]
        private Vector3 punch;

        [SerializeField]
        private float duration;

        [SerializeField]
        private int vibrato = 10;

        [SerializeField]
        private float elasticity = 1f;

        public override void Play(RectTransform rect, Vector2 _, TweenCallback callback = null)
        {
            rect.DOPunchScale(punch, duration, vibrato, elasticity).OnComplete(callback);
            
            //rect.localScale = Vector3.zero;
/*
            DOTween.Sequence()
                .Join(rect.DOScale(Vector3.one, duration / 2))
                .Join(rect.DOPunchScale(punch, duration / 2, vibrato, elasticity))
                .OnComplete(callback)
                .Play();*/
        }
    }
}