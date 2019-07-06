using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    private StarDisplay starDisplay;
    public int defenderStarCost;

    private void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }
    public void AddCurrencyStars(int amount)
    {
        starDisplay.AddStars(amount);
    }
    public void RemoveCurrencyStar(int amount)
    {
        starDisplay.UseStars(defenderStarCost);
    } 
}
