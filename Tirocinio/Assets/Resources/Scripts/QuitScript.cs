using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class QuitScript : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private GameObject videoPrefab;

    public Color buttonHover;
    private Image background;

    public void OnPointerEnter(PointerEventData eventData)
    {
        background = GetComponent<Image>();
        background.color = buttonHover;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        VideoPlayer videoPlayer = videoPrefab.GetComponentInChildren<VideoPlayer>();
        //videoPlayer.clip = Resources.Load<VideoClip>("VideoPlayer/Accensione");
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
