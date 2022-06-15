using Game.Settings;

namespace Core.Events
{
    public struct GameSettingsChangedEvent
    {
        public readonly GameSettings GameSettings;


        public GameSettingsChangedEvent(GameSettings gameSettings)
        {
            GameSettings = gameSettings;
        }
    }
}