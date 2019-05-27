using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    public AudioClip[] levelMusicArray;
    public AudioSource playerMusic;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        AudioClip levelMusic = levelMusicArray[level];
        if (levelMusic)
        {
            playerMusic.clip = levelMusic;
            playerMusic.loop = true;
            playerMusic.volume = PlayerPrefsManager.GetMasterVolume();
            if(SceneManager.GetActiveScene().name == "Win" || SceneManager.GetActiveScene().name == "Lose")
            {
                playerMusic.loop = false;
            }
            if (SceneManager.GetActiveScene().name == "Menu" || SceneManager.GetActiveScene().name == "Option")
            {
                playerMusic.PlayDelayed(1f);
            }
            else
            {
                playerMusic.Play();
            }
        }
    }

    public void ChangeVolume(float volume)
    {
        playerMusic.volume = volume;
    }
}
