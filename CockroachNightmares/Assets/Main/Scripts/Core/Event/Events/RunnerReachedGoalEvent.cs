using Game.Mechanics;

namespace Core.Events
{
    public class RunnerReachedGoalEvent
    {
        public readonly Runner Runner;


        public RunnerReachedGoalEvent(Runner runner)
        {
            Runner = runner;
        }
    }
}