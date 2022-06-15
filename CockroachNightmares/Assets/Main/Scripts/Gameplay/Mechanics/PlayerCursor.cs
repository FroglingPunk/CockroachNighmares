using Core.Events;
using UnityEngine;

namespace Game.Mechanics
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerCursor : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private Camera cam;


        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            cam = Camera.main;

            EventAggregator.AddListener<GameSettingsChangedEvent>(OnGameSettingsChanged);
            EventAggregator.AddListener<GameStateChangedEvent>(OnGameStateChanged);
        }

        private void Update()
        {
            Vector3 position = cam.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0f;
            transform.position = position;
        }

        private void OnDestroy()
        {
            EventAggregator.RemoveListener<GameSettingsChangedEvent>(OnGameSettingsChanged);
            EventAggregator.RemoveListener<GameStateChangedEvent>(OnGameStateChanged);
        }


        private void SetVisible(bool visible)
        {
            Cursor.visible = !visible;
            spriteRenderer.enabled = visible;
        }

        private void OnGameSettingsChanged(GameSettingsChangedEvent eventData)
        {
            transform.localScale = Vector3.one * 0.5f * eventData.GameSettings.PlayerCursorRadius;
        }

        private void OnGameStateChanged(GameStateChangedEvent eventData)
        {
            switch (eventData.State)
            {
                case EGameState.WaitingForStart:
                    SetVisible(false);
                    break;

                case EGameState.Run:
                    SetVisible(true);
                    break;

                case EGameState.Finished:
                    SetVisible(false);
                    break;
            }
        }
    }
}