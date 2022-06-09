using UnityEngine.UI;
using UnityEngine.EventSystems;


// Questo script gestisce i TabButton associati ai tab dell'interfaccia utente. Registra il button nel TabGroup, ne permette la selezione e l'interazione con l'utente, modificandone anche il colore e lo sprite.
namespace UnityEngine.XR.Tirocinio
{
    [RequireComponent(typeof(Image))]
    public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        public TabGroup tabGroup;
        public Image background;
        public bool selected;


        public void OnPointerClick(PointerEventData eventData)
        {
            selected = true;
            tabGroup.OnTabSelected(this);
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            tabGroup.OnTabEnter(this);
        }


        public void OnPointerExit(PointerEventData eventData)
        {
            tabGroup.OnTabExit();
        }


        void Start()
        {
            background = GetComponent<Image>();
            tabGroup.Subscribe(this);
        }
    }
}
