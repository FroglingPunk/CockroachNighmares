using Game.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    public class SettingsPanel : BasePanel
    {
        [SerializeField] private Slider sliderRunnerMovementAcceleration;
        [SerializeField] private Slider sliderRunnerMovementSpeed;
        [SerializeField] private Slider sliderPlayerCursorRadius;
        [SerializeField] private Slider sliderRunnersCount;

        public override EPanelType Type => EPanelType.Settings;


        public override void Init()
        {
            base.Init();

            UpdateSettings();

            sliderRunnerMovementAcceleration.onValueChanged.AddListener((value) => UpdateSettings());
            sliderRunnerMovementSpeed.onValueChanged.AddListener((value) => UpdateSettings());
            sliderPlayerCursorRadius.onValueChanged.AddListener((value) => UpdateSettings());
            sliderRunnersCount.onValueChanged.AddListener((value) => UpdateSettings());
        }


        private void UpdateSettings()
        {
            Settings.GameSettings = new GameSettings(
                sliderRunnerMovementAcceleration.value,
                sliderRunnerMovementSpeed.value,
                sliderPlayerCursorRadius.value,
                (int)sliderRunnersCount.value);
        }
    }
}