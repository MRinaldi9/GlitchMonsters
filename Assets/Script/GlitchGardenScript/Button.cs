using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject prefabDefender;
    public static GameObject SelectedDefender;
    private Text text;

    Button[] buttonArray;

    private void Start()
    {
        this.GetComponent<SpriteRenderer>().color = Color.black;
        buttonArray = FindObjectsOfType<Button>();

        DefenderCost();
    }


    private void DefenderCost()
    {
        Defender defender = prefabDefender.GetComponent<Defender>();
        if (text == null)
            text = GetComponentInChildren<Text>();

        text.text = defender.defenderStarCost.ToString();
    }

    private void OnMouseDown()
    {

        foreach (var thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        GetComponent<SpriteRenderer>().color = Color.white;

        SelectedDefender = prefabDefender;
    }
}
