using System.Collections.Generic;
using UnityEngine.UI;


// Questo script gestisce un insieme di Button, registrandoli al gruppo, colorandoli in base all'interazione con l'utente e attivando/disattivando i gameobject di conseguenza.
namespace UnityEngine.XR.Tirocinio
{
    public class ButtonGroup : MonoBehaviour
    {
        public List<Button> buttons;
        public Color buttonHover;
        public List<GameObject> objectsToSwap;
        [SerializeField] private GameObject arrowsPanel;
        [SerializeField] private UpdateScript updateScript;
        [SerializeField] private GameObject tabs;
        [SerializeField] private GameObject guidesPage;
        [SerializeField] private GameObject errorsPage;

        public Text testo;

        public void Start()
        {
            ResetButtons();
        }

        public void Subscribe(Button button)
        {
            if (buttons == null)
            {
                buttons = new List<Button>();
            }

            buttons.Add(button);
        }

        public void OnButtonEnter(Button button)
        {
            ResetButtons();
            button.background.color = buttonHover;
        }

        public void OnButtonExit()
        {
            ResetButtons();
        }

        public void OnButtonSelected(Button button)
        {
            ResetButtons();
            int index = button.transform.GetSiblingIndex();
            objectsToSwap[index].SetActive(true);
            
            arrowsPanel.SetActive(true);
            tabs.SetActive(false);

            if (button.name == "FaxButton" || button.name == "ScanButton" || button.name == "CopyButton")
            {
                guidesPage.SetActive(false);

                if(button.name == "FaxButton")
                    updateScript.state = UpdateScript.State.SwapToFax1;
                else if (button.name == "ScanButton")
                    updateScript.state = UpdateScript.State.SwapToScan1;
                else
                    updateScript.state = UpdateScript.State.SwapToCopy1;
            }
            else
            {
                errorsPage.SetActive(false);

                if (button.name == "TonerButton")
                    updateScript.state = UpdateScript.State.SwapToToner1;
                else if (button.name == "FogliButton")
                    updateScript.state = UpdateScript.State.SwapToFogli1;
                else
                    updateScript.state = UpdateScript.State.SwapToCarta;
            }                
        }

        public void ResetButtons()
        {
            foreach (Button button in buttons)
            {
                setColor(button);
            }
        }

        private void setColor(Button button)
        {
            Color color;

            if (button.name == "FaxButton" || button.name == "ScanButton" || button.name == "CopyButton")
            {
                ColorUtility.TryParseHtmlString("#7D7D7D", out color);
                button.background.color = color;
            }
            else
            {
                ColorUtility.TryParseHtmlString("#C23616", out color);
                button.background.color = color;
            }
        }
    }
}
