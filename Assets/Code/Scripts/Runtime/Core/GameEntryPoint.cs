using System;
using Game.Infrastructure.Interfaces;
using R3;
using UnityEngine;
using VContainer.Unity;

namespace Game.Core
{
    /// <summary>
    /// Основная входная точка приложения
    /// </summary>
    public class GameEntryPoint : IStartable, ITickable
    {
        public GameEntryPoint(IEventBus eventBus)
        {
            eventBus.Subscribe<Something>(Test);
            eventBus.Subscribe<Something>(Test);
            eventBus.Subscribe<Something>(Test);
            eventBus.Subscribe<Something>(Test);
            eventBus.Publish(new Something()
            {
                Test = "Hello World"
            });
            
            var subscription = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select((_, i) => i)
                .Where(x => x % 2 == 0)
                .Subscribe(x => Console.WriteLine($"Interval:{x}"));
        }
        
        public void Start()
        {
        }

        public void Tick()
        {
        }

        private void Test(Something s)
        {
            Debug.Log(s.Test);
        }
    }

    public class Something
    {
        public string Test { get; set; }
    }
}