namespace UnityEngine.XR.Tirocinio
{

    // Questo script associato ai Prefab può essere utilizzato per gestirne l'interazione con l'utente.
    public class InteractablePrefab : MonoBehaviour
    {
        public bool isSelected { get; set; }

        private void Awake()
        {
            isSelected = false;
        }
    }
}