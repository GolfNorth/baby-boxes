using System;
using System.Collections.Generic;
using Core.Infrastructure.Interfaces;
using R3;

namespace Core.Infrastructure
{
    /// <summary>
    /// Реализация <see cref="IEventBus"/> на основе библиотеки R3
    /// </summary>
    public class R3EventBus : IEventBus
    {
        private readonly Dictionary<Type, object> _eventSubjects = new Dictionary<Type, object>();

        public void Publish<TEvent>(TEvent eventMessage) where TEvent : class
        {
            var subject = GetOrCreateSubject<TEvent>();
            subject.OnNext(eventMessage);
        }

        public IDisposable Subscribe<TEvent>(Action<TEvent> onNext) where TEvent : class
        {
            var subject = GetOrCreateSubject<TEvent>();
            var adapter = new ActionToObserverAdapter<TEvent>(onNext);
            return subject.Subscribe(adapter);
        }

        private ISubject<TEvent> GetOrCreateSubject<TEvent>() where TEvent : class
        {
            var eventType = typeof(TEvent);

            if (!_eventSubjects.TryGetValue(eventType, out var subject))
            {
                subject = new Subject<TEvent>();
                _eventSubjects[eventType] = subject;
            }

            return (ISubject<TEvent>)subject;
        }
    }
}
