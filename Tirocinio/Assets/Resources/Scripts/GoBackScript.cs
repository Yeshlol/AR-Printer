using UnityEngine.EventSystems;
using UnityEngine.UI;


// Questo script associato al BackButtonPanel, gestisce l'interazione con l'utente attivando/disattivando gli elementi dell'interfaccia di conseguenza.
// Evidenzia il bottone, lo attiva e disattiva con i due metodi SetBackActive() e SetBackInactive(), modifica il testo delle pagine.
namespace UnityEngine.XR.Tirocinio
{
    public class GoBackScript : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        [SerializeField] private UpdateScript updateScript;
        [SerializeField] private GameObject arrowsPanel;
        [SerializeField] private GameObject cartaPage;
        [SerializeField] private GameObject copyPage;
        [SerializeField] private GameObject faxPage;
        [SerializeField] private GameObject fogliPage;
        [SerializeField] private GameObject guidesPage;
        [SerializeField] private GameObject scanPage;
        [SerializeField] private GameObject tabs;
        [SerializeField] private GameObject tonerPage;
        [SerializeField] private GameObject errorsPage;
        [SerializeField] private GoForwardScript goForwardScript;

        public Text testo;

        public Color buttonHover;
        public Image background;
        [HideInInspector] public bool clickable = true;


        public void ResetButton()
        {
            if (!clickable)
            {
                ColorUtility.TryParseHtmlString("#C23616", out Color color);
                background.color = color;
            }
            else
            {
                ColorUtility.TryParseHtmlString("#A4A4A4", out Color color);
                background.color = color;
            }
        }

        public void SetBackInactive()
        {
            clickable = false;
            ResetButton();
        }

        public void SetBackActive()
        {
            clickable = true;
            ResetButton();
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            if (clickable)
            {
                background.color = buttonHover;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ResetButton();
            Image image = GetComponent<Image>();
            var selectedSprite = Resources.Load<Sprite>("UI_Images/RIQUADRO_2");
            image.sprite = selectedSprite;
        }


        public void ReturnToIdle(int procedureNumber)
        {
            Text textPage;

            switch (procedureNumber)
            {
                case 1:
                    textPage = faxPage.GetComponent<Text>();
                    textPage.text = "1.Accendere la stampante";
                    faxPage.SetActive(false);
                    guidesPage.SetActive(true);
                    break;
                case 2:
                    textPage = scanPage.GetComponent<Text>();
                    textPage.text = "1.Accendere la stampante";
                    scanPage.SetActive(false);
                    guidesPage.SetActive(true);
                    break;
                case 3:
                    textPage = copyPage.GetComponent<Text>();
                    textPage.text = "1.Accendere la stampante";
                    copyPage.SetActive(false);
                    guidesPage.SetActive(true);
                    break;
                case 4:
                    tonerPage.SetActive(false);
                    errorsPage.SetActive(true);
                    break;
                case 5:
                    fogliPage.SetActive(false);
                    errorsPage.SetActive(true);
                    break;
                case 6:
                    cartaPage.SetActive(false);
                    errorsPage.SetActive(true);
                    break;
            }
            
            arrowsPanel.SetActive(false);            
            tabs.SetActive(true);
            updateScript.state = UpdateScript.State.ReturnToIdle;
            ResetButton();
        }

        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (clickable)
            {
                background.color = buttonHover;

                Image image = GetComponent<Image>();
                var selectedSprite = Resources.Load<Sprite>("UI_Images/RIQUADRO");
                image.sprite = selectedSprite;

                Text textPage;

                // Zona Fax
                if (updateScript.state == UpdateScript.State.Fax1)
                {
                    ReturnToIdle(1);
                }
                else if (updateScript.state == UpdateScript.State.Fax2)
                {
                    textPage = faxPage.GetComponent<Text>();

                    textPage.text = textPage.text.Replace("\n2. Premere il pulsante \"FAX\"", "");
                    updateScript.state = UpdateScript.State.BackToFax1;
                }
                else if (updateScript.state == UpdateScript.State.Fax3)
                {
                    textPage = faxPage.GetComponent<Text>();

                    textPage.text = textPage.text.Replace("\n3. Sollevare il coperchio scanner, inserire il documento da inviare e richiudere il coperchio", "");
                    updateScript.state = UpdateScript.State.BackToFax2;
                }
                else if (updateScript.state == UpdateScript.State.Fax4)
                {
                    textPage = faxPage.GetComponent<Text>();

                    textPage.text = textPage.text.Replace("\n4. Comporre il numero di fax destinatario, premere Inizio ed attendere il completamento.", "");
                    updateScript.state = UpdateScript.State.BackToFax3;

                    goForwardScript.SetForwardActive();
                }


                // Zona Scannerizzazione
                else if (updateScript.state == UpdateScript.State.Scan1)
                {
                    ReturnToIdle(2);
                }
                else if (updateScript.state == UpdateScript.State.Scan2)
                {
                    textPage = scanPage.GetComponent<Text>();

                    textPage.text = textPage.text.Replace("\n2. Collegare il cavo usb al dispositivo su cui ricevere l'immagine digitalizzata", "");
                    updateScript.state = UpdateScript.State.BackToScan1;
                }
                else if (updateScript.state == UpdateScript.State.Scan3)
                {
                    textPage = scanPage.GetComponent<Text>();

                    textPage.text = textPage.text.Replace("\n3. Premere il pulsante \"SCAN\"", "");
                    updateScript.state = UpdateScript.State.BackToScan2;
                }
                else if (updateScript.state == UpdateScript.State.Scan4)
                {
                    textPage = scanPage.GetComponent<Text>();

                    textPage.text = textPage.text.Replace("\n4. Sollevare il coperchio scanner, inserire il documento da scannerizzare e richiudere il coperchio", "");
                    updateScript.state = UpdateScript.State.BackToScan3;
                }
                else if (updateScript.state == UpdateScript.State.Scan5)
                {
                    textPage = scanPage.GetComponent<Text>();

                    textPage.text = textPage.text.Replace("\n5. Premere \"OK\" due volte e il tasto \"INIZIO\"", "");
                    updateScript.state = UpdateScript.State.BackToScan4;

                    goForwardScript.SetForwardActive();
                }


                // Zona Copy
                if (updateScript.state == UpdateScript.State.Copy1)
                {
                    ReturnToIdle(3);
                }
                else if (updateScript.state == UpdateScript.State.Copy2)
                {
                    textPage = copyPage.GetComponent<Text>();
                    textPage.text = textPage.text.Replace("\n2. Premere il pulsante \"COPIA\"", "");
                    updateScript.state = UpdateScript.State.BackToCopy1;
                    updateScript.Update();
                }
                else if (updateScript.state == UpdateScript.State.Copy3)
                {
                    textPage = copyPage.GetComponent<Text>();
                    textPage.text = textPage.text.Replace("\n3. Sollevare il coperchio scanner, inserire il documento da fotocopiare e richiudere il coperchio", "");
                    updateScript.state = UpdateScript.State.BackToCopy2;
                }
                else if (updateScript.state == UpdateScript.State.Copy4)
                {
                    textPage = copyPage.GetComponent<Text>();
                    textPage.text = textPage.text.Replace("\n4. Selezionare il numero di fotocopie desiderate, tramite il tastierino numerico, e premere il tasto \"Inizio\"", "");
                    updateScript.state = UpdateScript.State.BackToCopy3;

                    goForwardScript.SetForwardActive();
                }


                // Zona Toner
                if (updateScript.state == UpdateScript.State.Toner1)
                {
                    ReturnToIdle(4);
                }
                else if (updateScript.state == UpdateScript.State.Toner2)
                {
                    textPage = tonerPage.GetComponent<Text>();
                    textPage.text = textPage.text.Replace("\n2. Aprire lo sportello toner, ed estrarre il toner da sostituire", "");
                    updateScript.state = UpdateScript.State.BackToToner1;
                    updateScript.Update();
                }
                else if (updateScript.state == UpdateScript.State.Toner3)
                {
                    textPage = tonerPage.GetComponent<Text>();
                    textPage.text = textPage.text.Replace("\n3. Inserire il nuovo toner e chiudere lo sportello", "");
                    updateScript.state = UpdateScript.State.BackToToner2;

                    goForwardScript.SetForwardActive();
                }


                // Zona Fogli
                if (updateScript.state == UpdateScript.State.Fogli1)
                {
                    ReturnToIdle(5);
                }
                else if (updateScript.state == UpdateScript.State.Fogli2)
                {
                    textPage = fogliPage.GetComponent<Text>();
                    textPage.text = textPage.text.Replace("\n2. Inserire i fogli nel carrello", "");
                    updateScript.state = UpdateScript.State.BackToFogli1;
                    updateScript.Update();
                }
                else if (updateScript.state == UpdateScript.State.Fogli3)
                {
                    textPage = fogliPage.GetComponent<Text>();
                    textPage.text = textPage.text.Replace("\n3. Chiudere il carrello e attendere", "");
                    updateScript.state = UpdateScript.State.BackToFogli2;

                    goForwardScript.SetForwardActive();
                }


                // Zona Carta Inceppata
                if (updateScript.state == UpdateScript.State.Carta)
                {
                    ReturnToIdle(6);

                    goForwardScript.SetForwardActive();
                }
            }           
        }
    }
}
