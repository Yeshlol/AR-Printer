using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// Questo script associato al ForwardButtonPanel, gestisce l'interazione con l'utente attivando/disattivando gli elementi dell'interfaccia di conseguenza.
// Evidenzia il bottone, lo attiva e disattiva con i due metodi SetForwardActive() e SetForwardInactive(), modifica il testo delle pagine e mostra il prompt per l'incremento della stat.
namespace UnityEngine.XR.Tirocinio
{
    public class GoForwardScript : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        [SerializeField] private UpdateScript updateScript;
        [SerializeField] private GameObject cartaPage;
        [SerializeField] private GameObject copyPage;
        [SerializeField] private GameObject faxPage;
        [SerializeField] private GameObject fogliPage;
        [SerializeField] private GameObject forwardButton;
        [SerializeField] private GameObject scanPage;
        [SerializeField] private GameObject tonerPage;
        [SerializeField] private GameObject prompt;
        [SerializeField] private Text promptText;
        [SerializeField] private GoBackScript goBackScript;
        [SerializeField] private IncrementStatScript incrementStatScript;
        [SerializeField] private SelectPrefabScript selectPrefabScript;
        [SerializeField] private Text testoDebug;
        [SerializeField] private ShowStats showStats;


        public Color buttonHover;
        public Image background;
        public bool clickable = true;
        [HideInInspector] public int currentStat;



        public void ResetButton()
        {
            Color color;
            if (!clickable)
            {
                ColorUtility.TryParseHtmlString("#C23616", out color);
                background.color = color;
            }
            else 
            {
                ColorUtility.TryParseHtmlString("#A4A4A4", out color);
                background.color = color;
            }
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


        public void DisplayAgain()
        {
            showStats.coroutineDisplay = StartCoroutine(DisplayPrompt(currentStat));
        }


        public IEnumerator DisplayPrompt(int stat)
        {            
            prompt.SetActive(false);
            promptText.text = "Hai ";

            selectPrefabScript.interactable = false;

            if (stat == 1)
            {
                promptText.text += "inviato un Fax?";
            }
            else if (stat == 2)
            {
                promptText.text += "completato una Scansione?";
            }
            else
                promptText.text += "effettuato una Copia?";

            yield return new WaitForSeconds(10);

            prompt.SetActive(true);
        }


        public void SetForwardInactive()
        {
            clickable = false;
            ResetButton();
        }


        public void SetForwardActive()
        {
            clickable = true;
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
                    updateScript.state = UpdateScript.State.SwapToFax2;
                    textPage = faxPage.GetComponent<Text>();
                    textPage.text += "\n2. Premere il pulsante \"FAX\"";
                }
                else if (updateScript.state == UpdateScript.State.Fax2)
                {
                    updateScript.state = UpdateScript.State.SwapToFax3;
                    textPage = faxPage.GetComponent<Text>();
                    textPage.text += "\n3. Sollevare il coperchio scanner, inserire il documento da inviare e richiudere il coperchio";
                }
                else if (updateScript.state == UpdateScript.State.Fax3)
                {
                    updateScript.state = UpdateScript.State.SwapToFax4;
                    textPage = faxPage.GetComponent<Text>();
                    textPage.text += "\n4. Comporre il numero di fax destinatario, premere Inizio ed attendere il completamento.";
                    currentStat = 1;
                    showStats.coroutineDisplay = StartCoroutine(DisplayPrompt(currentStat));
                }


                // Zona Scannerizzazione
                else if (updateScript.state == UpdateScript.State.Scan1)
                {
                    updateScript.state = UpdateScript.State.SwapToScan2;
                    textPage = scanPage.GetComponent<Text>();
                    textPage.text += "\n2. Collegare il cavo usb al dispositivo su cui ricevere l'immagine digitalizzata";
                }
                else if (updateScript.state == UpdateScript.State.Scan2)
                {
                    updateScript.state = UpdateScript.State.SwapToScan3;
                    textPage = scanPage.GetComponent<Text>();
                    textPage.text += "\n3. Premere il pulsante \"SCAN\"";
                }
                else if (updateScript.state == UpdateScript.State.Scan3)
                {
                    updateScript.state = UpdateScript.State.SwapToScan4;
                    textPage = scanPage.GetComponent<Text>();
                    textPage.text += "\n4. Sollevare il coperchio scanner, inserire il documento da scannerizzare e richiudere il coperchio";
                }
                else if (updateScript.state == UpdateScript.State.Scan4)
                {
                    updateScript.state = UpdateScript.State.SwapToScan5;
                    textPage = scanPage.GetComponent<Text>();
                    textPage.text += "\n5. Premere \"OK\" due volte e il tasto \"INIZIO\"";
                    currentStat = 2;
                    showStats.coroutineDisplay = StartCoroutine(DisplayPrompt(currentStat));
                }


                // Zona Copy
                else if (updateScript.state == UpdateScript.State.Copy1)
                {
                    textPage = copyPage.GetComponent<Text>();
                    textPage.text += "\n2. Premere il pulsante \"COPIA\"";
                    updateScript.state = UpdateScript.State.SwapToCopy2;
                }
                else if (updateScript.state == UpdateScript.State.Copy2)
                {
                    textPage = copyPage.GetComponent<Text>();
                    textPage.text += "\n3. Sollevare il coperchio scanner, inserire il documento da fotocopiare e richiudere il coperchio";
                    updateScript.state = UpdateScript.State.SwapToCopy3;
                }
                else if (updateScript.state == UpdateScript.State.Copy3)
                {
                    textPage = copyPage.GetComponent<Text>();
                    textPage.text += "\n4. Selezionare il numero di fotocopie desiderate, tramite il tastierino numerico, e premere il tasto \"Inizio\"";
                    updateScript.state = UpdateScript.State.SwapToCopy4;
                    currentStat = 3;
                    showStats.coroutineDisplay = StartCoroutine(DisplayPrompt(currentStat));
                }


                // Zona Toner
                else if (updateScript.state == UpdateScript.State.Toner1)
                {
                    textPage = tonerPage.GetComponent<Text>();
                    textPage.text += "\n2. Aprire lo sportello toner, ed estrarre il toner da sostituire";
                    updateScript.state = UpdateScript.State.SwapToToner2;
                }
                else if (updateScript.state == UpdateScript.State.Toner2)
                {
                    textPage = tonerPage.GetComponent<Text>();
                    textPage.text += "\n3. Inserire il nuovo toner e chiudere lo sportello";
                    updateScript.state = UpdateScript.State.SwapToToner3;
                    SetForwardInactive();
                }


                // Zona Fogli
                else if (updateScript.state == UpdateScript.State.Fogli1)
                {
                    textPage = fogliPage.GetComponent<Text>();
                    textPage.text += "\n2. Inserire i fogli nel carrello";
                    updateScript.state = UpdateScript.State.SwapToFogli2;
                }
                else if (updateScript.state == UpdateScript.State.Fogli2)
                {
                    textPage = fogliPage.GetComponent<Text>();
                    textPage.text += "\n3. Chiudere il carrello e attendere";
                    updateScript.state = UpdateScript.State.SwapToFogli3;
                    SetForwardInactive();
                }
            }            
        }
    }
}