using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefManager : MonoBehaviour
{
    [HideInInspector]
    public float masterVolume = 100;
    [HideInInspector]
    public float musicVolume = 100;
    [HideInInspector]
    public float sfxVolume = 100;
    [HideInInspector]
    public float brightness = 0f;

    public AsyncOperation SceneOperation { get; set; }

    public Action OnOptionsUpdateAction;

    private static PlayerPrefManager instance;

    public static PlayerPrefManager Instance
    {
        get
        {
            return instance;
        }

        private set
        {
            instance = value;
        }

    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        LoadGame();
        DontDestroyOnLoad(this.gameObject);
    }

    /* 
    * Loads player perferences
    */
    public void LoadGame()
    {

        LoadSettings();

    }


    public void LoadSettings()
    {
        #region Load Settings
        // Master Volume
        if (PlayerPrefs.HasKey("Master Volume"))
        {
            masterVolume = PlayerPrefs.GetFloat("Master Volume", 100f);
            // Debug.Log("Loading Master Volume Setting, Current: " + masterVolume);
        }

        // Music Volume
        if (PlayerPrefs.HasKey("Music Volume"))
        {
            musicVolume = PlayerPrefs.GetFloat("Music Volume", 100f);
            // Debug.Log("Loading music Volume Setting, Current: " + musicVolume);
        }

        // SFX volume
        if (PlayerPrefs.HasKey("SFX Volume"))
        {
            sfxVolume = PlayerPrefs.GetFloat("SFX Volume", 100f);
            // Debug.Log("Loading SFX Volume Setting, Current : " + sfxVolume);
        }

        // Brightness
        if (PlayerPrefs.HasKey("Brightness"))
        {
            brightness = PlayerPrefs.GetFloat("Brightness", 100f);
            // Debug.Log("Loading Brightness Setting, Current: " + brightness);
        }

        #endregion
    }



    /* 
    * Saves player perferences
    */
    public void SaveGame()
    {
        // Save Player Settings
        PlayerPrefs.SetFloat("Master Volume", masterVolume);
        PlayerPrefs.SetFloat("Music Volume", musicVolume);
        PlayerPrefs.SetFloat("SFX Volume", sfxVolume);
        PlayerPrefs.SetFloat("Brightness", brightness);

    }

    public void ResetAllPlayerPrefs()
    {
        // Resetting settings to default
        PlayerPrefs.SetFloat("Master Volume", 100);
        PlayerPrefs.SetFloat("Music Volume", 100);
        PlayerPrefs.SetFloat("SFX Volume", 100);
        LoadGame();
    }
}
