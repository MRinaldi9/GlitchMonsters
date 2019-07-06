using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public float speed, damage;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = null;
        Health health = null;
        Defender defender = null;

        if (collision.gameObject.tag == "Attackers" && (gameObject.name == "Projectile(Clone)" || gameObject.name == "Sphere(Clone)"))
        {
            attacker = collision.gameObject.GetComponent<Attacker>();
            health = collision.gameObject.GetComponent<Health>();
        }
        else if (collision.gameObject.tag == "Defenders" && gameObject.name == "BallFire(Clone)")
        {
            defender = collision.gameObject.GetComponent<Defender>();
            health = collision.gameObject.GetComponent<Health>();
        }
        else if (collision.gameObject.tag == "Defenders" && (gameObject.name == "Projectile(Clone)" || gameObject.name == "Sphere(Clone)"))
        {
            return;
        }
        else if (collision.gameObject.tag == "Attackers" && this.gameObject.name == "BallFire(Clone)")
        {
            return;
        }

        if ((attacker && health) || (defender && health))
        {
            health.DamageDone(damage);
            Destroy(gameObject);
        }

    }

}
