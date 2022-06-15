using Core.Events;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    public class FinishPanel : BasePanel
    {
        [SerializeField] private Button buttonRestart;
        [SerializeField] private Button buttonQuit;

        public override EPanelType Type => EPanelType.Finish;


        public override void Init()
        {
            base.Init();

            buttonRestart.onClick.AddListener(() => EventAggregator.Invoke(new ButtonStartGamePressedEvent()));
            buttonQuit.onClick.AddListener(() => Application.Quit());
        }
    }
}