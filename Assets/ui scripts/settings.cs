using System;
using TMPro;
using System.Collections.Generic;
using UnityEngine;
public class settings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropDown;
    [SerializeField] private GameObject panelUI;
    [SerializeField] private GameObject panelofmainmenu;
    [SerializeField] public AudioSettings settings1;


    Resolution[] resolutions;
    // Start is called before the first frame update
    void Start()
    {
        
        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentIndexResolution = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentIndexResolution = i;
            }
        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.RefreshShownValue();
        LoadSettings(currentIndexResolution);
    }
    public void SetFullScreen(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;
    }
    
    public void SetResolution(int resolutionindex)
    {
        Resolution resolution = resolutions[resolutionindex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void LoadSettings(int currentIndexResolution)
    {
        if (PlayerPrefs.HasKey("ResolutionPrefrence"))
            resolutionDropDown.value = PlayerPrefs.GetInt("ResolutionPrefrence");
        else
            resolutionDropDown.value = currentIndexResolution;
        if (PlayerPrefs.HasKey("FullscreenPrefrence"))
            Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPrefrence"));
        else
            Screen.fullScreen = true;
            

    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("ResolutionPrefrence", resolutionDropDown.value);
        PlayerPrefs.SetInt("FullscreenPrefrence", Convert.ToInt32(Screen.fullScreen));
    }

    public void CloseSettings()
    {
        panelUI.SetActive(false);
        panelofmainmenu.SetActive(true);
    }


}
