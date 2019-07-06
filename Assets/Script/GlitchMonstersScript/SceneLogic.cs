using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLogic : MonoBehaviour
{
    private Image background;
    private Text[] text;
    private float AlphaIncrease;
    public float AlphaValue;


    // Use this for initialization
    void Start()
    {
        text = FindObjectsOfType<Text>();
        background = FindObjectOfType<Image>();
        for (int i = 0; i < text.Length; i++)
        {
            text[i].color = new Color(text[i].color.r, text[i].color.g, text[i].color.b, 0f);
        }
        background.color = new Color(background.color.r, background.color.g, background.color.b, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        AlphaIncrease += AlphaValue;
        for (int i = 0; i < text.Length; i++)
        {
            text[i].color = new Color(text[i].color.r, text[i].color.g, text[i].color.b, AlphaIncrease);
        }
        background.color = new Color(background.color.r, background.color.g, background.color.b, AlphaIncrease);
    }
}
