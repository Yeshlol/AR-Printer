using System.Collections.Generic;
using System.Linq;
using System;

namespace UnityEngine.XR.Tirocinio
{
    [Serializable]
    public class PieChartMeshController : MonoBehaviour
    {
        PieChartMesh mPieChart;

        List<float> Data = new List<float>(); 
        
        public Material mainMaterial;

        public GameObject Meshes, testobj, parent;

        internal bool createpieOnly;

        internal List<Color> customColor = new List<Color>();
        internal List<string> dataDescription = new List<string>();

        public enum AnimationType { NoAnimation, UpDown, Rotation, UpDownAndRotation }

        private void Awake()
        {
            Meshes = Resources.Load("PiePartsObj") as GameObject;

            GameObject cam = Camera.main.gameObject;
            if (cam != null)
            {
                if (cam.GetComponent<ClickEffect>() == null)
                {
                    cam.AddComponent<ClickEffect>();
                    if (cam.GetComponent<cakeslice.OutlineEffect>() == null)
                        cam.AddComponent<cakeslice.OutlineEffect>();
                }
            }
        }

        /// <summary>
        /// Generate Pie Chart
        /// </summary>
        /// <param name="randomData">Bool to generate random data</param>
        /// <param name="segments">how many data (each of the parts into which pie will be divided)</param>
        /// <param name="Data">data to show on pie</param>
        /// <param name="customColorofPie">bool for true for custom colors false random colors</param>
        /// <param name="customColor">color for Pie</param>
        /// <param name="dataDescription">Description about data to represent on the pie</param>
        /// <param name="dataHeadername">Name of data to represent on the pie</param>
        public void GenerateChart(int segment, AnimationType animationType, bool createpieOnly)
        {
            if (!createpieOnly)
            {
                GameObject LabelsCanvas = Instantiate(Resources.Load("Canvas") as GameObject);
                LabelsCanvas.name = "LabelsCanvas";
                //LabelsCanvas.SetActive(false);
                GameObject.Find("PieChart").GetComponent<PieChart>().deleteObjects.Add(LabelsCanvas);
            }
                

            this.createpieOnly = createpieOnly;

            
            if (Data.Count != segment)
            {
                Debug.LogError("Generating Random Data.\n\nThe DataList Count != segment");
                Data = GenerateRandomValues(segment).ToList();
            }
            if (mainMaterial == null)
            {
                Debug.LogError("Setting 'StandMat' as mat.");
                mainMaterial = Resources.Load("StandMat") as Material;
            }

            if (customColor.Count != segment)
            {
                Debug.LogError("Generating Random Color. \n\n ColorList Count != segment");
                customColor = GenerateRandomColors(segment).ToList();
            }

            if (gameObject.GetComponent<PieChartMesh>() == null)
                mPieChart = gameObject.AddComponent<PieChartMesh>();

            if (mPieChart != null)
            {
                mPieChart.Init(Data.ToArray(), mainMaterial, Meshes, animationType);
                mPieChart.Draw(Data.ToArray());
            }
            else
            {
                Debug.LogError("Piechart is null", gameObject);
            }
        }

        /// <summary>
        /// Set the Material Of Pie
        /// Note : call this before generating pie chart
        /// </summary>
        /// <param name="mat"></param>
        public void SetMatrialOfPie(Material mat)
        {
            mainMaterial = mat;
        }

        /// <summary>
        /// Set the color of the pie
        /// </summary>
        /// <param name="color">Color of the pie</param>
        public void SetColor(Color[] color)
        {
            customColor = color.ToList();
        }

        /// <summary>
        /// Data of the pie
        /// </summary>
        /// <param name="data"></param>
        public void SetData(float[] data)
        {
            this.Data = data.ToList();
        }

        /// <summary>
        /// Description of the pie
        /// </summary>
        /// <param name="data"></param>
        public void SetDescription(string[] data)
        {
            this.dataDescription = data.ToList();
        }


        float[] GenerateRandomValues(int length)
        {
            float[] targets = new float[length];
            for (int i = 0; i < length; i++)
            {
                targets[i] = Random.Range(1f, 100f);
            }
            return targets;
        }

        Color[] GenerateRandomColors(int length)
        {
            Color[] targets = new Color[length];
            for (int i = 0; i < length; i++)
            {
                Color c = new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)255);
                targets[i] = c;
            }
            return targets;
        }
    }
}