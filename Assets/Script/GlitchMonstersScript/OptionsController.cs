using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;
    private MusicManager manager;

    // Use this for initialization
    void Start()
    {
        manager = FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        manager.ChangeVolume(volumeSlider.value);

    }
    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty((int)difficultySlider.value);
        levelManager.LoadLevel("Menu");
    }
    public void DefaultsSettings()
    {
        volumeSlider.value = 0.5f;
        difficultySlider.value = 1f;
    }
}
