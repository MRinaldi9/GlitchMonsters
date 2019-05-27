using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderSpawner : MonoBehaviour
{
    private Camera cam;
    private Text text;
    private float currentTimer;
    private StarDisplay starDisplay;
    private Defender defender;

    public float timer;

    // Use this for initialization
    void Start()
    {
        cam = FindObjectOfType<Camera>();
        text = GameObject.Find("Warning").GetComponent<Text>();
        starDisplay = FindObjectOfType<StarDisplay>();
        currentTimer = timer;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            text.enabled = false;
            timer = currentTimer;
        }
    }
    private void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorldPointsWithMouseClick();
        Vector2 exactPos = SnapToGrid(rawPos);
        GameObject newDefender = Button.SelectedDefender;

        if ((exactPos.x <= 3) && (starDisplay.UseStars(newDefender.GetComponent<Defender>().defenderStarCost) == StarDisplay.Status.SUCCESS))
            Instantiate(newDefender, exactPos, Quaternion.identity, GameObject.Find("Defenders").transform);
        else if (exactPos.x > 3)
        {
            text.enabled = true;
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
            text.text = "You can't place the defenders over four squares";
        }
        else if (starDisplay.UseStars(newDefender.GetComponent<Defender>().defenderStarCost) == StarDisplay.Status.FAILURE)
        {
            text.enabled = true;
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
            text.text = "You don't have enough Stars currency for invoke a Defender";
        }
    }

    private Vector2 CalculateWorldPointsWithMouseClick()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private Vector2 SnapToGrid(Vector2 rawPositionsWorld)
    {
        int exactMousePosX = Mathf.RoundToInt(rawPositionsWorld.x);
        int exactMousePosY = Mathf.RoundToInt(rawPositionsWorld.y);

        return new Vector2(exactMousePosX, exactMousePosY);
    }
}
