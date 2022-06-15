using Core.Events;

namespace Game.Settings
{
    public static class Settings
    {
        private static GameSettings gameSettings;
        public static GameSettings GameSettings
        {
            get => gameSettings;
            set
            {
                gameSettings = value;
                EventAggregator.Invoke(new GameSettingsChangedEvent(gameSettings));
            }
        }


        static Settings()
        {
            GameSettings = GameSettings.Default;
        }
    }
}