using UnityEngine;

namespace Game.Mechanics
{
    public class RunnerEmotions : MonoBehaviour
    {
        [SerializeField] private Runner runner;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float minPanicTimeForCrying = 5f;


        private void Update()
        {
            spriteRenderer.enabled = (runner.PanicTime > minPanicTimeForCrying);
        }
    }
}