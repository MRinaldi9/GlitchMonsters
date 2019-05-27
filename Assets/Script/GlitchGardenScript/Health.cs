using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;

    public void DamageDone(float damage)
    {
        health -= damage;
    }
    public void isDied()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        isDied();
    }
}
