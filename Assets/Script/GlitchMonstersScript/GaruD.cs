using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class GaruD : MonoBehaviour
{
    Animator animator;
    Attacker attacker;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && !collision.gameObject.GetComponent<Defender>())
        {
            return;
        }
        else if (collision.name == "Panel")
        {
            return;
        }
        else if (collision.tag == "Attackers")
        {
            return;
        }
        else if (collision.gameObject.layer == 10)
        {
            return;
        }
        else
        {
            GameObject obj = collision.gameObject;
            attacker.Attack(obj);
            animator.SetBool("IsAttacking", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision = null;
            return;
        }
        else if (collision.gameObject.layer != 8)
        {
            if (collision.GetComponent<Health>().health <= 0f)
            {
                animator.SetBool("IsAttacking", false);
            }
        }
    }
}
