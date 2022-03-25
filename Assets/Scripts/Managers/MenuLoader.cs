
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuLoader : MonoBehaviour
{
    public static MenuLoader Instance;

    [SerializeField] private AudioMixer am_AudioMixer;

    [SerializeField] private TMP_Dropdown dd_DropDown;

    Resolution[] r_Resolutions;

    private int _currentResolutionIndex = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        r_Resolutions = Screen.resolutions;

        dd_DropDown.ClearOptions();

        List<string> _options = new List<string>();


        for (int i = 0; i< r_Resolutions.Length; i++)
        {
            string _option = r_Resolutions[i].width + " x " + r_Resolutions[i].height;
            _options.Add(_option);

            if(r_Resolutions[i].width == Screen.currentResolution.width && r_Resolutions[i].height == Screen.currentResolution.height)
            {
                _currentResolutionIndex = i;
            }
        }

        dd_DropDown.AddOptions(_options);
        dd_DropDown.value = _currentResolutionIndex;
        dd_DropDown.RefreshShownValue();

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = r_Resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        am_AudioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
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
