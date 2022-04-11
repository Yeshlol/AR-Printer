using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PressedPrefab : MonoBehaviour, IPointerClickHandler
{
    private bool pressed;
    public Canvas canvas;
    public Text text;

    void Start()
    {
        pressed = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        text.text = "Provaaaa";
    }
}
