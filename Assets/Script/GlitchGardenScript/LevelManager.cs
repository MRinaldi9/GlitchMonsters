using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private Scene CurrentScene;
    public float delay;

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void QuitLevel()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevelManager()
    {
        delay -= Time.deltaTime;

        CurrentScene = SceneManager.GetActiveScene();

        if (SceneManager.GetActiveScene().name == "Win" && delay <= 0f)
        {
            SceneManager.LoadScene("Menu");
        }
        else if (SceneManager.GetActiveScene().name == "Lose" && delay <= 0f)
        {
            SceneManager.LoadScene("Menu");
        }
    }
    private void FixedUpdate()
    {
        LoadLevelManager();
    }
}
