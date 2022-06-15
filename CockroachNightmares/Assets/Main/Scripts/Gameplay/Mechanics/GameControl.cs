using Core.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Game;

namespace Game.Mechanics
{
    public class GameControl : MonoBehaviour
    {
        [SerializeField] private Runner runnerPrefab;
        [SerializeField] private Transform destinationPointTransform;
        [SerializeField] private Transform spawnPointTransform;

        private EGameState state;
        public EGameState State
        {
            get => state;
            set
            {
                state = value;
                EventAggregator.Invoke(new GameStateChangedEvent(state));
            }
        }

        private List<Runner> activeRunners = new List<Runner>();


        private void Awake()
        {
            EventAggregator.AddListener<ButtonStartGamePressedEvent>(OnButtonStartGamePressed);
            EventAggregator.AddListener<RunnerReachedGoalEvent>(OnRunnerReachedGoal);
        }

        private void Start()
        {
            State = EGameState.WaitingForStart;
        }

        private void OnDestroy()
        {
            EventAggregator.RemoveListener<ButtonStartGamePressedEvent>(OnButtonStartGamePressed);
            EventAggregator.RemoveListener<RunnerReachedGoalEvent>(OnRunnerReachedGoal);
        }


        private void OnButtonStartGamePressed(ButtonStartGamePressedEvent eventData)
        {
            StartGame();
        }

        private void OnRunnerReachedGoal(RunnerReachedGoalEvent eventData)
        {
            RemoveRunner(eventData.Runner);

            if (activeRunners.Count == 0)
            {
                FinishGame();
            }
        }

        private void StartGame()
        {
            if (State != EGameState.Run)
            {
                State = EGameState.Run;
                StartCoroutine(SpawnRunners());
            }
        }

        private void FinishGame()
        {
            if (State == EGameState.Run)
            {
                StopAllCoroutines();
                RemoveAllRunners();
                State = EGameState.Finished;
            }
        }

        private void RemoveRunner(Runner runner)
        {
            if (activeRunners.Contains(runner))
            {
                activeRunners.Remove(runner);
                Destroy(runner.gameObject);
            }
        }

        private void RemoveAllRunners()
        {
            for (int i = 0; i < activeRunners.Count; i++)
            {
                Destroy(activeRunners[i]);
            }

            activeRunners.Clear();
        }


        private IEnumerator SpawnRunners()
        {
            WaitForSeconds delay = new WaitForSeconds(0.5f);

            for (int i = 0; i < Settings.Settings.GameSettings.RunnersCount; i++)
            {
                Vector3[] path;

                if (Settings.Settings.GameSettings.RunnersCount > 1 && i != 0)
                {
                    path = RunnerPathGenerator.GeneratePath(spawnPointTransform.position, destinationPointTransform.position);
                }
                else
                {
                    path = new Vector3[] { destinationPointTransform.position };
                }

                Runner runner = Instantiate(runnerPrefab, spawnPointTransform.position, spawnPointTransform.rotation, transform);
                runner.Init(path, Settings.Settings.GameSettings.RunnerMovementSpeed, Settings.Settings.GameSettings.RunnerMovementAcceleration);
                activeRunners.Add(runner);

                yield return delay;
            }
        }
    }
}