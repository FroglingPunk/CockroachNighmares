using UnityEngine;

namespace UI.Menu
{
    public abstract class BasePanel : MonoBehaviour, IPanel
    {
        public abstract EPanelType Type { get; }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public virtual void Init()
        {

        }
    }
}