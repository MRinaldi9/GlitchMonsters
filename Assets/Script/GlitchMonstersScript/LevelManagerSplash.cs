using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManagerSplash : MonoBehaviour
{
    public float delay = 2.5f;
    public Image splashScreen;
    public Image FadeOut;
    public float incrementAlphaValue;

    private float AlphaValue;
    private float AlphaValueFadeOut;
    private Text text;


    public void LoadLevelAfter(string name)
    {
        delay -= Time.deltaTime;
        if (delay <= 0f)
            SceneManager.LoadScene(name);
    }
    // Use this for initialization
    void Start()
    {
        FadeOut.color = new Color(0, 0, 0, 0);
        text = FindObjectOfType<Text>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
        splashScreen.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        LoadLevelAfter("Menu");
        if (AlphaValue >= 0 && AlphaValue <= 1)
            AlphaValue += incrementAlphaValue;
        if (AlphaValue >= 1)
            AlphaValue = 1;
        splashScreen.color = new Color(1, 1, 1, AlphaValue);
        text.color = new Color(text.color.r, text.color.g, text.color.b, AlphaValue);
        if (splashScreen.color.a == 1 && Time.timeSinceLevelLoad >= 3f)
        {
            AlphaValueFadeOut += incrementAlphaValue;
            FadeOut.color = new Color(0, 0, 0, AlphaValueFadeOut);
        }


    }
}
