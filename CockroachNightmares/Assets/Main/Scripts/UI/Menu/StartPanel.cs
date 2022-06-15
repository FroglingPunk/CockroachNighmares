using Core.Events;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    public class StartPanel : BasePanel
    {
        [SerializeField] private Button buttonStart;

        public override EPanelType Type => EPanelType.Start;


        public override void Init()
        {
            base.Init();

            buttonStart.onClick.AddListener(() => EventAggregator.Invoke(new ButtonStartGamePressedEvent()));
        }
    }
}