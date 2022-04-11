using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityEngine.XR.Tirocinio
{
    public class GoBackScript : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private UpdateScript updateScript;
        [SerializeField] private GameObject arrowsPanel;
        [SerializeField] private GameObject cartaPage;
        [SerializeField] private GameObject copyPage;
        [SerializeField] private GameObject faxPage;
        [SerializeField] private GameObject fogliPage;
        [SerializeField] private GameObject forwardButton;
        [SerializeField] private GameObject guidesPage;
        [SerializeField] private GameObject scanPage;
        [SerializeField] private GameObject tabs;
        [SerializeField] private GameObject tonerPage;
        [SerializeField] private GameObject errorsPage;

        public Text testo;

        public void OnPointerClick(PointerEventData eventData)
        {
            ArrowButton arrowButton = forwardButton.GetComponent<ArrowButton>();
            Text textPage;

            // Zona Fax
            if (updateScript.state == UpdateScript.State.Fax1)
            {
                arrowsPanel.SetActive(false);
                faxPage.SetActive(false);
                guidesPage.SetActive(true);
                tabs.SetActive(true);
                updateScript.state = UpdateScript.State.ReturnToIdle;
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

                arrowButton.active = true;
                ExecuteEvents.Execute<IPointerExitHandler>(forwardButton, new PointerEventData(EventSystem.current), ExecuteEvents.pointerExitHandler);
            }


            // Zona Scannerizzazione
            else if (updateScript.state == UpdateScript.State.Scan1)
            {
                arrowsPanel.SetActive(false);
                scanPage.SetActive(false);
                guidesPage.SetActive(true);
                tabs.SetActive(true);
                updateScript.state = UpdateScript.State.ReturnToIdle;
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

                arrowButton.active = true;
                ExecuteEvents.Execute<IPointerExitHandler>(forwardButton, new PointerEventData(EventSystem.current), ExecuteEvents.pointerExitHandler);
            }


            // Zona Copy
            if (updateScript.state == UpdateScript.State.Copy1)
            {
                arrowsPanel.SetActive(false);
                copyPage.SetActive(false);
                guidesPage.SetActive(true);
                tabs.SetActive(true);
                updateScript.state = UpdateScript.State.ReturnToIdle;
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
                arrowButton.active = true;
                ExecuteEvents.Execute<IPointerExitHandler>(forwardButton, new PointerEventData(EventSystem.current), ExecuteEvents.pointerExitHandler);
            }


            // Zona Toner
            if (updateScript.state == UpdateScript.State.Toner1)
            {
                arrowsPanel.SetActive(false);
                tonerPage.SetActive(false);
                errorsPage.SetActive(true);
                tabs.SetActive(true);
                updateScript.state = UpdateScript.State.ReturnToIdle;
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
                arrowButton.active = true;
                ExecuteEvents.Execute<IPointerExitHandler>(forwardButton, new PointerEventData(EventSystem.current), ExecuteEvents.pointerExitHandler);
            }


            // Zona Fogli
            if (updateScript.state == UpdateScript.State.Fogli1)
            {
                arrowsPanel.SetActive(false);
                fogliPage.SetActive(false);
                errorsPage.SetActive(true);
                tabs.SetActive(true);
                updateScript.state = UpdateScript.State.ReturnToIdle;
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
                arrowButton.active = true;
                ExecuteEvents.Execute<IPointerExitHandler>(forwardButton, new PointerEventData(EventSystem.current), ExecuteEvents.pointerExitHandler);
            }


            // Zona Carta Inceppata
            if (updateScript.state == UpdateScript.State.Carta)
            {
                arrowsPanel.SetActive(false);
                cartaPage.SetActive(false);
                errorsPage.SetActive(true);
                tabs.SetActive(true);
                updateScript.state = UpdateScript.State.ReturnToIdle;
                arrowButton.active = true;
                ExecuteEvents.Execute<IPointerExitHandler>(forwardButton, new PointerEventData(EventSystem.current), ExecuteEvents.pointerExitHandler);
            }
        }
    }
}

