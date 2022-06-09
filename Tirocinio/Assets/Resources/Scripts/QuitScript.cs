using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;


// Questo script gestisce l'interazione dell'utente con il bottone QuitButton, modificandone il colore, e chiude l'applicazione alla pressione del tasto.
public class QuitScript : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public Color buttonHover;
    private Image background;

    public void OnPointerEnter(PointerEventData eventData)
    {
        background = GetComponent<Image>();
        background.color = buttonHover;
    }

    public void OnPointerClick(PointerEventData eventData)
    {        
        Application.Quit();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        background = GetComponent<Image>();
        Color color;
        ColorUtility.TryParseHtmlString("#C23616", out color);
        background.color = color;
    }
}
