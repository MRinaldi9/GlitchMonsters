using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    private Text starDisplay;
    public int storageNumber = 20;
    public enum Status { SUCCESS, FAILURE }


    // Use this for initialization
    void Start()
    {
        starDisplay = GetComponent<Text>();
        starDisplay.text = storageNumber.ToString();
    }

    public void AddStars(int amount)
    {
        storageNumber += amount;
        starDisplay.text = storageNumber.ToString();
    }
    public Status UseStars(int amount)
    {
        if (storageNumber >= amount)
        {
            storageNumber -= amount;
            starDisplay.text = storageNumber.ToString();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }
}
