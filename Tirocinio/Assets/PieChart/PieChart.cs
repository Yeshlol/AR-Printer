using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace UnityEngine.XR.Tirocinio
{
    public class PieChart : MonoBehaviour
    {
        [Tooltip("Object of PieChartMeshController")]
        public PieChartMeshController pieChartMeshController;

        [Tooltip("Each of the parts into which the will be divided")]
        public int segments;

        [Tooltip("The data for the pie\nThe size of this list must exact the value of Segment.")]
        public float[] Data;

        [Tooltip("Main Material that the mesh of the pie will use to rander")]
        public Material mainMaterial;

        [Tooltip("The colors that will be applied on the pie\nThe size of this list must exact the value of Segment.")]
        public Color[] customColors;

        [Tooltip("Pie chart with not information and title")]
        public bool justCreateThePie;

        [Tooltip("The list of description of the pie.")]
        public List<string> dataDescription = new List<string>();

        [Tooltip("Type of animation which will the pie have.")]
        public PieChartMeshController.AnimationType animationType;

        [Tooltip("Assign the parent Object where the Pie will generate")]
        public Transform parentTransform;
        
        [HideInInspector]
        public List<GameObject> deleteObjects;


        public void SpawnChart()
        {   if (pieChartMeshController == null)
                pieChartMeshController = gameObject.AddComponent<PieChartMeshController>();

            pieChartMeshController.parent = parentTransform.gameObject;

            //GameObject goTestoDebug = GameObject.Find("TestoDebug");
            //Text testo = goTestoDebug.GetComponent<Text>();
            //testo.text += "X = " + parentTransform.position.x + "\nY = " + parentTransform.position.y + "\nZ  = " + parentTransform.position.z + "\n";
            //parentTransform.position += new Vector3(-5f, -5f, 0);
            //testo.text += "X = " + parentTransform.position.x + "\nY = " + parentTransform.position.y + "\nZ  = " + parentTransform.position.z + "\n";

            if (pieChartMeshController == null)
            {
                Debug.LogError("Drag The PieChartMeshController to Scene as PieChartMeshController is null.");
                return;
            }
            if (mainMaterial != null)
                pieChartMeshController.SetMatrialOfPie(mainMaterial);

            pieChartMeshController.SetData(Data);
            pieChartMeshController.SetColor(customColors);
            pieChartMeshController.SetDescription(dataDescription.ToArray());
            pieChartMeshController.GenerateChart(segments, animationType, justCreateThePie);
            //StartCoroutine(RescaleChart());
        }


        public void DestroyChart()
        {
            //GameObject goTestoDebug = GameObject.Find("TestoDebug");
            //Text testo = goTestoDebug.GetComponent<Text>();

            foreach (GameObject obj in deleteObjects)
            {
                //testo.text += "Ho eliminato" + obj.name;
                Destroy(obj);                
            }
            deleteObjects.Clear();
        }


        public IEnumerator RescaleChart()
        {
            yield return new WaitForSeconds(1);

            foreach (Transform child in transform)
            {
                child.localScale = new Vector3(0.5f, 0.1f, 0.5f);
            }
        }


        public void ReverseAnimation(Animation anim, string AnimationName)
        {
            anim[AnimationName].speed = -1;
            anim[AnimationName].time = anim[AnimationName].length;
            anim.CrossFade(AnimationName);
        }


        public void ForwardAnimation(Animation anim, string AnimationName)
        {
            anim[AnimationName].speed = 1;
            anim[AnimationName].time = 0;
            anim.CrossFade(AnimationName);
        }
    }        
}