using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseShredder : MonoBehaviour
{
    private LifeCounter lifeCounter;

    // Use this for initialization
    void Start()
    {
        lifeCounter = FindObjectOfType<LifeCounter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
            Destroy(collision.gameObject);
        else
        {
            Destroy(collision.gameObject);
            lifeCounter.RemoveLife(1);
        }
    }
}
