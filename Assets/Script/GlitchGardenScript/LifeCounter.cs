using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    [SerializeField]
    private int NumberOfLife;

    private Text numberText;
    private LevelManager levelManager;

    // Use this for initialization
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        numberText = GetComponent<Text>();
        numberText.text = NumberOfLife.ToString();
    }

    public void RemoveLife(int amount)
    {
        if (NumberOfLife > 0)
        {
            NumberOfLife -= amount;
            numberText.text = NumberOfLife.ToString();
        }
        else
        {
            levelManager.LoadLevel("Lose");
        }
    }
}
