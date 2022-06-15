using UnityEngine;
using UnityEngine.UI;

namespace UI.Utils
{
    [RequireComponent(typeof(Text))]
    public class SliderCurrentValueText : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        private Text textCurrentValue;


        private void Awake()
        {
            textCurrentValue = GetComponent<Text>();

            if (textCurrentValue)
            {
                slider.onValueChanged.AddListener((value) => textCurrentValue.text = value.ToString());
            }
        }
    }
}