using UnityEngine.UI;
using UnityEngine.EventSystems;

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

        // Start is called before the first frame update
        void Start()
        {
            background = GetComponent<Image>();
            tabGroup.Subscribe(this);
        }
    }
}
