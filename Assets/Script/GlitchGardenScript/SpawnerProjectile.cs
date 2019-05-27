using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerProjectile : MonoBehaviour
{
    public GameObject prefabsProjectiles;

    private GameObject newProjectile;
    private GameObject Projectiles;
    private Animator animator;
    private AnimatorStateInfo animatorState;
    private Spawner LaneSpawner;


    private void Start()
    {
        animator = GetComponent<Animator>();
        animatorState = animator.GetCurrentAnimatorStateInfo(0);

        Projectiles = GameObject.Find("Projectiles");

        if (!Projectiles)
        {
            Projectiles = new GameObject("Projectiles");
        }
    }

    private void Update()
    {
        animatorState = animator.GetCurrentAnimatorStateInfo(0);
        SetMyLaneSpawner();

        if (AttackerInLane() && animatorState.IsName("RyzeGIdle"))
        {
            animator.SetBool("IsAttacking", true);
        }
        else if (!AttackerInLane() && animatorState.IsName("RyzeGAttack"))
        {
            animator.SetBool("IsAttacking", false);
        }

        if (AttackerInLane() && animatorState.IsName("DoruGIdle"))
        {
            if (animatorState.normalizedTime >= 2f)
            {
                animator.SetBool("IsAttacking", true);
            }
        }
        else if (AttackerInLane() && animatorState.IsName("DoruGAttack"))
        {
            if (animatorState.normalizedTime >= 1f)
            {
                animator.SetBool("IsAttacking", false);
            }
        }
        else if (!AttackerInLane() && animatorState.IsName("DoruGAttack"))
        {
            animator.SetBool("IsAttacking", false);
        }
    }


    private bool AttackerInLane()
    {
        if (gameObject.tag == "Defenders")
        {
            if (LaneSpawner.transform.childCount <= 0)
                return false;

            foreach (Transform attacker in LaneSpawner.transform)
            {
                if (attacker.position.x > this.transform.position.x)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void SetMyLaneSpawner()
    {
        if (gameObject.tag == "Defenders")
        {
            Spawner[] spawners = FindObjectsOfType<Spawner>();

            foreach (var currentLaneSpawner in spawners)
            {
                if (currentLaneSpawner.transform.position.y == this.transform.position.y)
                {
                    LaneSpawner = currentLaneSpawner;
                }
                else if (LaneSpawner == null)
                {
                }
            }
        }

    }

    private void Fire()
    {
        newProjectile = Instantiate(prefabsProjectiles);
        newProjectile.transform.position = GetComponentInChildren<Transform>().Find("SpawnerProjectiles").position;
        newProjectile.transform.parent = GameObject.Find("Projectiles").transform;
    }
}
