using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{ 
    public static void SaveSceneNumber()
    {
        //Uses the binary formatter to read all the data and convert it to binary

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/griddata.bpw";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData();

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Saving has worked, it is stored in" + path);
    }

    //Reads the binary data from the file and converts it back to usable data
    public static SaveData LoadSceneNumber()
    {
        string path = Application.persistentDataPath + "/griddata.bpw";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
