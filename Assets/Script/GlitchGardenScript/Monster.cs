using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Monster : MonoBehaviour
{
    Animator animator;
    Attacker attacker;
    private float CurrentPosX;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();

        CurrentPosX = this.transform.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && !collision.gameObject.GetComponent<Defender>())
        {
            return;
        }
        else if (collision.tag == "Attackers")
        {
            return;
        }
        else if (collision.name == "Panel")
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
            animator.SetBool("IsAttackingMelee", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 10)
        {
            return;
        }

        if (collision.GetComponent<Health>().health <= 0f)
        {
            animator.SetBool("IsAttackingMelee", false);
        }
    }
    private void RangedAttack(int value)
    {
        bool condition;
        if (value == 1)
            condition = true;
        else
            condition = false;
        animator.SetBool("IsAttackingRanged", condition);
    }
    private void OnAnimatorMove()
    {
        if (this.transform.position.x <= CurrentPosX - RandomTrigger())
        {
            RangedAttack(1);
            CurrentPosX = this.transform.position.x;
        }
    }
    private int RandomTrigger()
    {
        return Random.Range(1, 4);
    }
}
