using UnityEngine.UI;
using UnityEngine.Video;


// Questo script permette la selezione degli elementi in Realtà Aumentata tramite il tocco da parte dell'utente. Verrà generato un Ray che eventualmente andrà a colpire il collider di un Prefab con lo script InteractablePrefab associato.
// A questo punto verrà attivato il relativo GameObject in primo piano alla selezione e successivamente ad un secondo tocco, verrà riattivato il Prefab e disattivato l'elemento in primo piano.
namespace UnityEngine.XR.Tirocinio
{
    public class SelectPrefabScript : MonoBehaviour
    {
        [SerializeField] private Text testoDebug; // DEBUG
        [SerializeField] private ShowAR showAR;
        [SerializeField] private UpdateScript updateScript;
        [SerializeField] private Camera arCamera;
        [SerializeField] private GameObject UIStampante;
        [SerializeField] private GameObject showStatsButton;
        [SerializeField] private GameObject showARButton;
        [SerializeField] private GoBackScript goBackScript;
        [SerializeField] private GoForwardScript goForwardScript;
        [SerializeField] private Canvas canvasFullScreen;
        [SerializeField] private GameObject videoFullScreen;

        private bool selected;
        public bool interactable;
        private InteractablePrefab interactablePrefab;


        private void Awake()
        {
            interactable = true;
            selected = false;
        }


        void Update()
        {
            if (Input.touchCount > 0 && interactable && goBackScript.clickable)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    //testoDebug.text += "\nState: " + updateScript.state;
                    Ray ray = arCamera.ScreenPointToRay(touch.position);
                    RaycastHit hitObject;

                    if (Physics.Raycast(ray, out hitObject))
                    {
                        if (!showAR.hidden)
                        {
                            if (selected)
                            {
                                UnselectPrefab();
                            }
                            else {
                                interactablePrefab = hitObject.transform.GetComponent<InteractablePrefab>();
                                SelectPrefab();
                            }                   
                        }                        
                    }
                    else if (selected)
                        UnselectPrefab();                    
                }
            }
        }


        private void UnselectPrefab()
        {
            canvasFullScreen.gameObject.SetActive(false);
            videoFullScreen.gameObject.SetActive(false);

            UIStampante.SetActive(true);
            showStatsButton.SetActive(true);
            showARButton.SetActive(true);
            interactablePrefab.gameObject.SetActive(true);

            selected = false;
        }



        private void FullScreenImage()
        {
            canvasFullScreen.GetComponentInChildren<Image>().sprite = updateScript.currentSprite;
            canvasFullScreen.gameObject.SetActive(true);
        }


        private void FullScreenVideo()
        {
            VideoPlayer videoPlayer = videoFullScreen.GetComponentInChildren<VideoPlayer>();
            videoPlayer.url = updateScript.currentUrl;
            videoFullScreen.SetActive(true);
        }


        void SelectPrefab()
        {
            selected = true;
            interactablePrefab.gameObject.SetActive(false);
            UIStampante.SetActive(false);
            showStatsButton.SetActive(false);
            showARButton.SetActive(false);

            if (updateScript.state == UpdateScript.State.Fax2 || updateScript.state == UpdateScript.State.Fax4 || updateScript.state == UpdateScript.State.Scan3 ||
                updateScript.state == UpdateScript.State.Scan5 || updateScript.state == UpdateScript.State.Fax2 || updateScript.state == UpdateScript.State.Copy2 ||
                updateScript.state == UpdateScript.State.Copy4)
                FullScreenImage();
            else
                FullScreenVideo();            
        }
    }
}