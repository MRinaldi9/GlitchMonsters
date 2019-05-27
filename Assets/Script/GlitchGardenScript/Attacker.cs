using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField]
    [Range(-1f, 1.5f)]
    private float Speed;

    public float spawnEvery;

    private GameObject CurrentTarget;
    Health health;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * Speed * Time.deltaTime);

        if (CurrentTarget == null)
        {
            if (this.gameObject.name == "GaruD")
                animator.SetBool("IsAttacking", false);
            else if (this.gameObject.name == "Monster")
                animator.SetBool("IsAttackingMelee", false);
        }
    }
    public void SetSpeed(float speed)
    {
        this.Speed = speed;
    }
    public void AttackerCurrentTarget(float damage)
    {
        if (CurrentTarget)
        {
            health = CurrentTarget.GetComponent<Health>();
            if (health)
            {
                health.DamageDone(damage);
            }
        }
    }
    public void Attack(GameObject obj)
    {
        CurrentTarget = obj;
    }


}
