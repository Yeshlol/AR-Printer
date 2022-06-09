using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;


// Questo script gestisce l'interazione dell'utente con il tasto ShowButton, modificandone il colore e attivando/disattivando tutti gli elementi in Realtà Aumentata istanziati.
namespace UnityEngine.XR.Tirocinio
{
    public class ShowAR : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        [SerializeField] private Text testo; // DEBUG
        [SerializeField] private PrefabImagePairManager prefImagePairManager;

        [HideInInspector]
        public bool hidden = false;

        [SerializeField] private Color buttonHover;
        private Image background;


        public void OnPointerEnter(PointerEventData eventData)
        {
            background = GetComponent<Image>();
            background.color = buttonHover;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            //testo.text += "\nHidden = " + hidden + "\n";
            //testo.text += "\nState = " + updateScript.state + "\n;
            Dictionary<Guid, GameObject> prefabs = prefImagePairManager.m_Instantiated;
                        
            if (hidden)
            {                
                foreach (KeyValuePair<Guid, GameObject> prefab in prefabs)
                {
                    prefab.Value.SetActive(true);
                }

                hidden = false;
                SetColor();
            }
            else
            {
                foreach (KeyValuePair<Guid, GameObject> prefab in prefabs)
                {
                    prefab.Value.SetActive(false);
                }
                                
                hidden = true;
                SetColor();
            }            
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            SetColor();
        }

        private void SetColor()
        {
            Color color;
            background = this.GetComponent<Image>();

            if (!hidden)
            {
                ColorUtility.TryParseHtmlString("#FBC531", out color);
                background.color = color;
            }
            else
            {
                ColorUtility.TryParseHtmlString("#44BD32", out color);
                background.color = color;
            }
        }
    }    
}
