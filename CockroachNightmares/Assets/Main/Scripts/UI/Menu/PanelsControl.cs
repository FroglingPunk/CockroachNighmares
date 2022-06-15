using System.Collections.Generic;
using UnityEngine;

namespace UI.Menu
{
    [System.Serializable]
    public class PanelsControl
    {
        [SerializeField] private BasePanel[] panels;


        public void Init()
        {
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].Init();
            }
        }

        public void ShowPanel(EPanelType type, bool hideOthers = true)
        {
            if (hideOthers)
            {
                HideAll();
            }

            for (int i = 0; i < panels.Length; i++)
            {
                if (panels[i].Type == type)
                {
                    panels[i].Show();
                    break;
                }
            }
        }

        public void ShowPanels(IEnumerable<EPanelType> panels, bool hideOther = true)
        {
            if (hideOther)
            {
                HideAll();
            }

            foreach (EPanelType panel in panels)
            {
                ShowPanel(panel, false);
            }
        }

        public void HideAll()
        {
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].Hide();
            }
        }
    }
}