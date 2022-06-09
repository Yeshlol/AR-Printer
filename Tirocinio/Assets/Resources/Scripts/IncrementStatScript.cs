using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;


// Questo script gestisce l'interazione dell'utente con il YesButtonPanel, modificandone il colore e sprite. 
// Inoltre alla pressione, nasconde il Prompt ed avvia la coroutine per inviare la request al server per incrementare la statistica dell'operazione completata.
namespace UnityEngine.XR.Tirocinio
{
    public class IncrementStatScript : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        [SerializeField] private Color buttonHover;
        [SerializeField] private Text text;
        [SerializeField] private GameObject prompt;
        [SerializeField] private Text promptText;
        [SerializeField] private GoForwardScript goForwardScript;
        [SerializeField] private GoBackScript goBackScript;
        [SerializeField] private SelectPrefabScript selectPrefabScript;

        private bool clickable = true;

        public void ResetButton()
        {
            ColorUtility.TryParseHtmlString("#323232", out Color color);
            text.color = color;
            clickable = true;
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            Image image = GetComponent<Image>();
            var selectedSprite = Resources.Load<Sprite>("UI_Images/RIQUADRO");
            image.sprite = selectedSprite;
            text.color = buttonHover;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ResetButton();
            Image image = GetComponent<Image>();
            var selectedSprite = Resources.Load<Sprite>("UI_Images/RIQUADRO_2");
            image.sprite = selectedSprite;
        }


        private void IncrementStat(int stat)
        {
            string url = "http://93.41.140.68:8000/api/stat_increment/" + stat;

            byte[] myData = new System.Text.UTF8Encoding().GetBytes("Prova");
            UnityWebRequest request = UnityWebRequest.Put(url, myData);

            request.SendWebRequest();

            StartCoroutine(HidePrompt(stat));
        }


        private IEnumerator HidePrompt(int statNumber)
        {
            yield return new WaitForSeconds(1);

            promptText.text = "Hai ";
            goForwardScript.SetForwardActive();
            goBackScript.SetBackActive();

            prompt.SetActive(false);
            ResetButton();
            goBackScript.ReturnToIdle(statNumber);
            selectPrefabScript.interactable = true;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            if (clickable)
            {
                clickable = false;                

                IncrementStat(goForwardScript.currentStat);
            }
        }
    }
}    
