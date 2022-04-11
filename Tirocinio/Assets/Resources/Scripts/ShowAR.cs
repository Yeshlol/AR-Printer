using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace UnityEngine.XR.Tirocinio
{
    public class ShowAR : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        [SerializeField]
        private Text testo;
        [SerializeField]
        private PrefabImagePairManager prefImagePairManager;

        [HideInInspector]
        public bool hidden = false;


        public Color buttonHover;
        private Image background;

        public void OnPointerEnter(PointerEventData eventData)
        {
            background = GetComponent<Image>();
            background.color = buttonHover;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //testo.text += "\nState = " + updateScript.state;
            Dictionary<Guid, GameObject> prefabs = prefImagePairManager.m_Instantiated;
                        
            if (hidden)
            {                
                foreach (KeyValuePair<Guid, GameObject> prefab in prefabs)
                {
                    prefab.Value.SetActive(true);
                }

                SetColor();                
                hidden = false;
            }
            else
            {
                foreach (KeyValuePair<Guid, GameObject> prefab in prefabs)
                {
                    prefab.Value.SetActive(false);
                }

                SetColor();                
                hidden = true;
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

            if (hidden)
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
