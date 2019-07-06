using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float levelTimerSlider;


    private Text text;
    private LevelManager levelManager;
    private Slider slider;
    private float levelValueSlider;
    private float littleDelay = 5f;


    // Use this for initialization
    void Start()
    {
        levelTimerSlider *= PlayerPrefsManager.GetDifficulty();
        slider = this.GetComponent<Slider>();
        levelManager = FindObjectOfType<LevelManager>();
        text = GetComponentInChildren<Text>();

        text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        levelValueSlider = Time.timeSinceLevelLoad / levelTimerSlider;
        slider.value = levelValueSlider;

        if (slider.value >= slider.maxValue)
        {
            littleDelay -= Time.deltaTime;
            text.gameObject.SetActive(true);

            if (littleDelay <= 0 && !(SceneManager.GetActiveScene().name == "Level_03"))
                levelManager.LoadNextLevel();
            else if (SceneManager.GetActiveScene().name == "Level_03" && littleDelay <= 0)
                levelManager.LoadLevel("Win");
        }
    }
}
