using UnityEngine;

namespace Game.Mechanics
{
    public class Runner : MonoBehaviour, IPanicable
    {
        public enum ERunnerState
        {
            Relax,
            Panic
        }

        private const float MIN_TIME_FOR_RELAX = 0.4f;

        [SerializeField] private float rotationSpeed = 480f;

        private Vector3 spawnPoint;
        private Vector3[] path;
        private int currentPathPoint;

        private float currentMovementSpeed;
        private float targetRunMovementSpeed;
        private float runAwayMovementSpeed;
        private float accelerationSpeed;

        private Vector3 panicSource;
        private ERunnerState state = ERunnerState.Relax;

        public float RelaxTime { get; private set; } = MIN_TIME_FOR_RELAX;
        public float PanicTime { get; private set; } = 0f;


        private void Update()
        {
            if (path == null || path.Length == 0)
            {
                return;
            }

            if (state == ERunnerState.Relax)
            {
                RelaxTime += Time.deltaTime;
            }
            else
            {
                PanicTime += Time.deltaTime;
            }

            if (state == ERunnerState.Relax && RelaxTime > MIN_TIME_FOR_RELAX)
            {
                currentMovementSpeed = Mathf.MoveTowards(currentMovementSpeed, targetRunMovementSpeed, accelerationSpeed * Time.deltaTime);
                MoveAndRotate(path[currentPathPoint]);

                if (transform.position == path[currentPathPoint])
                {
                    currentPathPoint++;

                    if (currentPathPoint >= path.Length)
                    {
                        currentPathPoint = 0;
                    }
                }
            }
            else
            {
                currentMovementSpeed = Mathf.MoveTowards(currentMovementSpeed, runAwayMovementSpeed, accelerationSpeed * Time.deltaTime);
                MoveAndRotate(transform.position + (transform.position - panicSource));
            }
        }


        public void Panic(Vector3 panicSource)
        {
            this.panicSource = panicSource;
            state = ERunnerState.Panic;
            RelaxTime = 0f;
        }

        public void Relax()
        {
            state = ERunnerState.Relax;
            PanicTime = 0f;
        }

        public void Init(Vector3[] path, float movementSpeed, float accelerationSpeed)
        {
            this.accelerationSpeed = accelerationSpeed;
            this.path = path;
            targetRunMovementSpeed = movementSpeed;
            runAwayMovementSpeed = movementSpeed * 1.5f;
            spawnPoint = transform.position;

            transform.rotation = Quaternion.LookRotation(Vector3.forward, path[currentPathPoint] - transform.position);

            state = ERunnerState.Relax;
        }


        private void MoveAndRotate(Vector3 target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, currentMovementSpeed * Time.deltaTime);

            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, target - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}