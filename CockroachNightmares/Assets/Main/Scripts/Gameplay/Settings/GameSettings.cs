namespace Game.Settings
{
    public class GameSettings
    {
        public readonly float RunnerMovementAcceleration;
        public readonly float RunnerMovementSpeed;
        public readonly float PlayerCursorRadius;
        public readonly int RunnersCount;

        public static GameSettings Default => new GameSettings(3f, 3f, 3f, 1);


        public GameSettings(float runnerMovementAcceleration, float runnerMovementSpeed, float playerCursorRadius, int runnersCount)
        {
            RunnerMovementAcceleration = runnerMovementAcceleration;
            RunnerMovementSpeed = runnerMovementSpeed;
            PlayerCursorRadius = playerCursorRadius;
            RunnersCount = runnersCount;
        }
    }
}