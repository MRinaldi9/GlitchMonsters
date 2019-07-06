using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallS : MonoBehaviour
{
    private Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();

        if (attacker)
            animator.SetBool("UnderAttack", true);
    }
}
