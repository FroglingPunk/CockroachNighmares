using UnityEngine;

namespace Utils.Game
{
    public class MovementScreenLimit : MonoBehaviour
    {
        [SerializeField] private bool checkForTransformScaleChanges = false;

        private Camera cam;

        private Vector2 xLimit = new Vector2();
        private Vector2 yLimit = new Vector2();

        private Vector3 previousTransformScale;


        private void Awake()
        {
            cam = Camera.main;

            if (checkForTransformScaleChanges)
            {
                previousTransformScale = transform.lossyScale;
            }

            CalculateLimits();
        }

        private void LateUpdate()
        {
            if (checkForTransformScaleChanges && previousTransformScale != transform.lossyScale)
            {
                CalculateLimits();
            }

            Vector3 limitedPosition = transform.position;
            limitedPosition.x = Mathf.Clamp(limitedPosition.x, xLimit.x, xLimit.y);
            limitedPosition.y = Mathf.Clamp(limitedPosition.y, yLimit.x, yLimit.y);
            transform.position = limitedPosition;
        }


        private void CalculateLimits()
        {
            xLimit.x = -cam.orthographicSize * Screen.width / Screen.height + transform.lossyScale.x * 0.5f;
            xLimit.y = cam.orthographicSize * Screen.width / Screen.height - transform.lossyScale.x * 0.5f;

            yLimit.x = -cam.orthographicSize + transform.lossyScale.y * 0.5f;
            yLimit.y = cam.orthographicSize - transform.lossyScale.y * 0.5f;
        }
    }
}