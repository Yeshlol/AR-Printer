using UnityEngine;
using UnityEngine.EventSystems;


// Questo script permette all'utente di trascinare l'UI-Stampante trascinando la label superiore
public class DragWindow : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform dragRectTransform;

    #region IDragHandler implementation
    public void OnDrag(PointerEventData eventData)
    {        
        dragRectTransform.anchoredPosition += eventData.delta;
    }
    #endregion


    #region IEndDragHandler implementation
    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragRectTransform.position.x < Screen.width * 0.35 || dragRectTransform.position.x > Screen.width * 0.64)
            dragRectTransform.position = new Vector3(Screen.width * 0.45f, dragRectTransform.position.y, 0);

        if (dragRectTransform.position.y < Screen.height * 0.21 || dragRectTransform.position.y > Screen.height * 0.79)
            dragRectTransform.position = new Vector3(dragRectTransform.position.x, Screen.height * 0.2f, 0);
    }
    #endregion

}