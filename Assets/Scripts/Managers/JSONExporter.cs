using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class JSONExporter : MonoBehaviour
{
    public void OutputJSON()
    {
        string s_Output = JsonUtility.ToJson(GameManager.Instance);
        File.WriteAllText(Application.dataPath + "/ExportFile.txt", s_Output);
    }
}