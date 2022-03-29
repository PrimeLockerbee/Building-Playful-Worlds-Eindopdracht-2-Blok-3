using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveData
{
    public int _sceneNumber;

    //Saves the current scene number using the buildIndex number
    public SaveData()
    {
        _sceneNumber = SceneManager.GetActiveScene().buildIndex;
    }
}
