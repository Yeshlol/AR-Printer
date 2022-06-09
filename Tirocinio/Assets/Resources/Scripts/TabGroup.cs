using System.Collections.Generic;


// Questo script gestisce i TabButton associati ai tab dell'interfaccia utente. Registra il button nel TabGroup, ne permette la selezione e l'interazione con l'utente, modificandone anche il colore e lo sprite.
// Alla selezione di un tab, verrà attivato soltanto il GameObject associato ad esso, mentre gli altri verranno disattivati.
namespace UnityEngine.XR.Tirocinio
{
    public class TabGroup : MonoBehaviour
    {
        public List<TabButton> tabButtons;
        public Color tabHover;
        public TabButton selectedTab;
        public List<GameObject> objectsToSwap;
        

        public void Start()
        {
            ResetTabs();
            SetSelected(selectedTab);
        }

        public void Subscribe(TabButton button)
        {
            if (tabButtons == null)
            {
                tabButtons = new List<TabButton>();
            }

            tabButtons.Add(button);
        }

        public void OnTabEnter(TabButton button)
        {
            ResetTabs();
            
            button.background.color = tabHover;
        }

        public void OnTabExit()
        {
            ResetTabs();
        }

        public void OnTabSelected(TabButton button)
        {            
            foreach(TabButton b in tabButtons)
            {
                if (b.GetInstanceID() != button.GetInstanceID())
                {
                    b.selected = false;
                }
            }

            ResetTabs();
            SetSelected(button);

            int index = button.transform.GetSiblingIndex();
            for (int i = 0; i < objectsToSwap.Count; i++)
            {
                if (i == index)
                {
                    objectsToSwap[i].SetActive(true);
                }
                else
                {
                    objectsToSwap[i].SetActive(false);
                }
            }
        }

        public void ResetTabs()
        {
            foreach (TabButton button in tabButtons)
            {  
                if (!button.selected)
                {
                    var unselectedSprite = Resources.Load<Sprite>("UI_Images/Button");
                    button.background.sprite = unselectedSprite;
                }
                SetColor(button);
            }
        }

        private void SetColor(TabButton button)
        {
            Color color;

            if (button.name == "InfoTab")
            {
                ColorUtility.TryParseHtmlString("#44BD32", out color);
                button.background.color = color;

            }
            else if (button.name == "GuidesTab")
            {
                ColorUtility.TryParseHtmlString("#FBC531", out color);
                button.background.color = color;
            }
            else {
                ColorUtility.TryParseHtmlString("#C23616", out color);
                button.background.color = color;
            }
        }

        private void SetSelected (TabButton button)
        {
            button.selected = true;

            var selectedSprite = Resources.Load<Sprite>("UI_Images/PressedButton");
            button.background.sprite = selectedSprite;
        }
    }
}
    
