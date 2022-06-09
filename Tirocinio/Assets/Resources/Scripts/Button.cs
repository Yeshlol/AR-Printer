using UnityEngine.UI;
using UnityEngine.EventSystems;


// Questo script gestisce l'interazione dell'utente con un bottone, indicando quale bottone evidenziare al ButtonGroup.
namespace UnityEngine.XR.Tirocinio
{
    [RequireComponent(typeof(Image))]
    public class Button : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        public ButtonGroup buttonGroup;
        public Image background;

        public void OnPointerClick(PointerEventData eventData)
        {
            buttonGroup.OnButtonSelected(this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            buttonGroup.OnButtonEnter(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            buttonGroup.OnButtonExit();
        }

        // Start is called before the first frame update
        void Start()
        {
            background = GetComponent<Image>();
            buttonGroup.Subscribe(this);
        }
    }
}
