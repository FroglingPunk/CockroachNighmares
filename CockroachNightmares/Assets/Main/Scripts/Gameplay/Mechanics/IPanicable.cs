using UnityEngine;

namespace Game.Mechanics
{
    public interface IPanicable
    {
        void Panic(Vector3 panicSource);
        void Relax();
    }
}