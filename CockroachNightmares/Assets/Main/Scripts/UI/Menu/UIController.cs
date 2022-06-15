using UnityEngine;
using Core.Events;
using Game.Mechanics;

namespace UI.Menu
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private PanelsControl panelsControl;


        private void Awake()
        {
            EventAggregator.AddListener<GameStateChangedEvent>(OnGameStateChanged);
        }

        private void Start()
        {
            panelsControl.Init();
        }

        private void OnDestroy()
        {
            EventAggregator.RemoveListener<GameStateChangedEvent>(OnGameStateChanged);
        }


        private void OnGameStateChanged(GameStateChangedEvent eventData)
        {
            switch (eventData.State)
            {
                case EGameState.WaitingForStart:
                    panelsControl.ShowPanels(
                        new EPanelType[] { EPanelType.Start, EPanelType.Settings },
                        true);
                    break;

                case EGameState.Run:
                    panelsControl.HideAll();
                    break;

                case EGameState.Finished:
                    panelsControl.ShowPanels(
                        new EPanelType[] { EPanelType.Finish, EPanelType.Settings },
                        true);
                    break;
            }
        }
    }
}