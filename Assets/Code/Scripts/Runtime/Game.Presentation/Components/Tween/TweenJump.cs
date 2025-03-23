using System;
using DG.Tweening;
using UnityEngine;

namespace Game.Presentation.Components
{
    [Serializable]
    public class TweenJump : TweenBase
    {
        [SerializeField]
        private float jumpPower;

        [SerializeField]
        private int numJumps = 10;

        [SerializeField]
        private float duration;

        public override void Play(RectTransform rect, Vector2 destination, TweenCallback callback = null)
        {
            rect.DOJumpAnchorPos(destination, jumpPower, numJumps, duration).OnComplete(callback);
        }
    }
}