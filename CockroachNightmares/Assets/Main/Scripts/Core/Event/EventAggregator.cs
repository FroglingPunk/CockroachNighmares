using System;
using System.Collections.Generic;

namespace Core.Events
{
    public static class EventAggregator
    {
        private static Dictionary<Type, Delegate> Subscribers { get; } = new Dictionary<Type, Delegate>();


        public static void AddListener<T>(Action<T> action)
        {
            if (!Subscribers.ContainsKey(typeof(T)))
            {
                Subscribers.Add(typeof(T), null);
            }

            Subscribers[typeof(T)] = Delegate.Combine(Subscribers[typeof(T)], action);
        }

        public static void RemoveListener<T>(Action<T> action)
        {
            if (Subscribers.ContainsKey(typeof(T)))
            {
                Subscribers[typeof(T)] = Delegate.Remove(Subscribers[typeof(T)], action);
            }
        }

        public static void Clear()
        {
            Subscribers.Clear();
        }

        public static void Invoke<T>(T obj)
        {
            if (!Subscribers.ContainsKey(typeof(T)))
            {
                RegisterType<T>();
            }

            Action<T> handler = (Action<T>)Subscribers[typeof(T)];
            handler?.Invoke(obj);
        }

        private static void RegisterType<T>()
        {
            if (!Subscribers.ContainsKey(typeof(T)))
            {
                Subscribers[typeof(T)] = null;
            }
        }
    }
}