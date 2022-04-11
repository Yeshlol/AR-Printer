using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace UnityEngine.XR.Tirocinio
{
    [RequireComponent(typeof(Image))]
    public class ArrowButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        public Color buttonHover;
        public Image background;

        [HideInInspector]
        public bool active;

        public void Start()
        {
            active = true;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            ResetButton();
        }

        public void ResetButton()
        {
            Color color;
            if(active)
            {
                ColorUtility.TryParseHtmlString("#A4A4A4", out color);
                background.color = color;
            }
            else
            {
                ColorUtility.TryParseHtmlString("#C23616", out color);
                background.color = color;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (active)
            {
                ResetButton();
                background.color = buttonHover;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (active)
            {
                ResetButton();
            }
        }        
    }
}