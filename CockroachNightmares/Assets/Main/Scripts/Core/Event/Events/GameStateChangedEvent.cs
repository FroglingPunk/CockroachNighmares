using Game.Mechanics;

namespace Core.Events
{
    public struct GameStateChangedEvent
    {
        public readonly EGameState State;

        public GameStateChangedEvent(EGameState state)
        {
            State = state;
        }
    }
}