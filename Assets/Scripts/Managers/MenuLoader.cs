
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
    public static MenuLoader Instance;

    private void Awake()
    {
        Instance = this;
    }

    //Loads a scene according to name
    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    //Quits the Game
    public void QuitGame()
    {
        Application.Quit();
    }
}
