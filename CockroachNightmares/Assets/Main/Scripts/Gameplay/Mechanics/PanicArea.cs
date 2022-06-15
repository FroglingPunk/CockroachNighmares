using UnityEngine;

namespace Game.Mechanics
{
    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
    public class PanicArea : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IPanicable panicable))
            {
                panicable.Panic(transform.position);
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IPanicable panicable))
            {
                panicable.Panic(transform.position);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IPanicable panicable))
            {
                panicable.Relax();
            }
        }
    }
}