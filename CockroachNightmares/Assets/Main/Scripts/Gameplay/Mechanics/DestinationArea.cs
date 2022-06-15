using Core.Events;
using UnityEngine;

namespace Game.Mechanics
{
    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
    public class DestinationArea : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Runner runner))
            {
                EventAggregator.Invoke(new RunnerReachedGoalEvent(runner));
            }
        }
    }
}