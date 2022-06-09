using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.Networking;


// Questo script gestisce l'interazione dell'utente con il tasto ShowStats, modificandone il colore, e avviando al click la coroutine DisplayStats() che andrà a recuperare le statistiche di utilizzo memorizzate,
// inviando UnityWebRequest al web server. Successivamente, il web server invierà le statistiche nel formato JSON, esse verranno passate al PieChartScript e verrà avviata la procedura per spawnarlo.
namespace UnityEngine.XR.Tirocinio
{
    public class ShowStats : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        private bool hidden;

        private Coroutine coroutine;
        public Coroutine coroutineDisplay;
        private Image background;

        [SerializeField] private Color buttonHover;
        [SerializeField] private PieChart pieChartScript;
        [SerializeField] private GameObject UI;
        [SerializeField] private GameObject showARButton;
        [SerializeField] private SelectPrefabScript selectPrefabScript;
        [SerializeField] private UpdateScript updateScript;
        [SerializeField] private GoForwardScript goForwardScript;

        private void Start()
        {
            hidden = true;
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            ColorUtility.TryParseHtmlString("#31EAFB", out Color color);
            background = GetComponent<Image>();
            background.color = color;
        }


        private IEnumerator DisplayStats()
        {  
           for (int statID = 1; statID < 4; statID++)
           {
                string url = "http://93.41.140.68:8000/api/stat/" + statID;
                Debug.Log("Sending request url: " + url);
                UnityWebRequest webRequest = UnityWebRequest.Get(url);

                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                        Debug.LogError("Error: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError("HTTP Error: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.Success:
                        Stat stat = JsonUtility.FromJson<Stat>(webRequest.downloadHandler.text);
                        //Debug.Log("Stat" + statID + ": " + stat.quantity + "\n");

                        pieChartScript.Data[statID - 1] = stat.quantity;
                        pieChartScript.dataDescription[statID - 1] = stat.name;

                        if (statID == 3)
                        {
                            yield return new WaitForSeconds(10);
                            UI.SetActive(false);
                            pieChartScript.SpawnChart();
                        }
                        break;
                }
           }
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            ExecuteEvents.Execute(showARButton, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);

            if (hidden)
            {
                if (coroutineDisplay != null)
                {
                    StopCoroutine(coroutineDisplay);
                    coroutineDisplay = null;
                }

                coroutine = StartCoroutine(DisplayStats());                
                hidden = false;
            }
            else
            {
                StopCoroutine(coroutine);

                if (updateScript.state == UpdateScript.State.Fax4 || updateScript.state == UpdateScript.State.Scan5 || updateScript.state == UpdateScript.State.Copy4)
                    coroutineDisplay = StartCoroutine(goForwardScript.DisplayPrompt(goForwardScript.currentStat));

                pieChartScript.DestroyChart();
                UI.SetActive(true);
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
                ColorUtility.TryParseHtmlString("#3166FB", out color);
                background.color = color;
            }
            else
            {
                ColorUtility.TryParseHtmlString("#C23616", out color);
                background.color = color;
            }
        }
    }
}
