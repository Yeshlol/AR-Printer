using UnityEngine.EventSystems;
using UnityEngine.UI;


// Questo script gestisce l'interazione dell'utente con il NoButtonPanel, modificandone il colore e sprite. 
// Inoltre alla pressione, nasconde il Prompt ed avvia la coroutine per mostrare successivamente di nuovo il Prompt.
namespace UnityEngine.XR.Tirocinio
{
    public class NoButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        [SerializeField] private Color buttonHover;
        [SerializeField] private Text text;
        [SerializeField] private Text testoDebug;
        [SerializeField] private GameObject prompt;
        [SerializeField] private Text promptText;
        [SerializeField] private GoBackScript goBackScript;
        [SerializeField] private GoForwardScript goForwardScript;
        [SerializeField] private SelectPrefabScript selectPrefabScript;
        [SerializeField] private UpdateScript updateScript;



        public void ResetButton()
        {
            ColorUtility.TryParseHtmlString("#323232", out Color color);
            text.color = color;
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


        public void OnPointerClick(PointerEventData eventData)
        {
            ResetButton();            
            selectPrefabScript.interactable = true;
            goBackScript.SetBackActive();
            goForwardScript.DisplayAgain();
        }        
    }            
}
