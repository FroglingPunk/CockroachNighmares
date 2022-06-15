using UnityEngine;

namespace Utils.Game
{
    public static class RunnerPathGenerator
    {
        public static Vector3[] GeneratePath(Vector3 startPoint, Vector3 finishPoint)
        {
            Vector3 randomPoint = new Vector3(
                Random.Range(startPoint.x, finishPoint.x),
                Random.Range(startPoint.y, finishPoint.y),
                finishPoint.z); ;

            return new Vector3[] { randomPoint, finishPoint };
        }
    }
}