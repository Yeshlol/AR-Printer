using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityEngine.XR.Tirocinio
{
    public class GoForwardScript : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private UpdateScript updateScript;
        [SerializeField] private GameObject cartaPage;
        [SerializeField] private GameObject copyPage;
        [SerializeField] private GameObject faxPage;
        [SerializeField] private GameObject fogliPage;
        [SerializeField] private GameObject forwardButton;
        [SerializeField] private GameObject scanPage;
        [SerializeField] private GameObject tonerPage;


        public Text testo;

        public void OnPointerClick(PointerEventData eventData)
        {
            ArrowButton arrowButton = forwardButton.GetComponent<ArrowButton>();

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
                arrowButton.active = false;
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
                arrowButton.active = false;
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
                arrowButton.active = false;
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
                arrowButton.active = false;
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
                arrowButton.active = false;
            }
        }
    }
}