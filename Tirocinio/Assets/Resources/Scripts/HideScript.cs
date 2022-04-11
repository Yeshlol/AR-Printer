using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace UnityEngine.XR.Tirocinio
{
    public class HideScript : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject tabs;
        [SerializeField] private GameObject body;
        [SerializeField] private GameObject arrowsPanel;
        [SerializeField] private Image minusImage;
        [SerializeField] private UpdateScript updateScript;
        [HideInInspector]
        public bool hidden = false;

        public void OnPointerClick(PointerEventData eventData)
        {
            Color color;
            Image buttonImage = this.GetComponent<Image>();

            if (!hidden)
            {
                ColorUtility.TryParseHtmlString("#44BD32", out color);
                buttonImage.color = color;
                Sprite plusSprite = Resources.Load<Sprite>("UI_Images/plus");
                minusImage.sprite = plusSprite;
                body.SetActive(false);
                arrowsPanel.SetActive(false);
                tabs.SetActive(false);
                
                hidden = true;
            }
            else
            {
                ColorUtility.TryParseHtmlString("#C23616", out color);
                buttonImage.color = color;
                Sprite minusSprite = Resources.Load<Sprite>("UI_Images/minus");
                minusImage.sprite = minusSprite;
                body.SetActive(true);

                if(updateScript.state != UpdateScript.State.Idle)
                    arrowsPanel.SetActive(true);
                if(updateScript.state == UpdateScript.State.Idle)
                    tabs.SetActive(true);

                hidden = false;
            }
        }
    }
}
