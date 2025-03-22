using System;
using R3;

namespace Game.SDK.Infrastructure
{
    public class ActionToObserverAdapter<T> : Observer<T>
    {
        private readonly Action<T> _onNext;

        public ActionToObserverAdapter(Action<T> onNext)
        {
            _onNext = onNext ?? throw new ArgumentNullException(nameof(onNext));
        }

        protected override void OnNextCore(T value)
        {
            _onNext(value);
        }

        protected override void OnErrorResumeCore(Exception error)
        {
        }

        protected override void OnCompletedCore(Result result)
        {
        }
    }
}