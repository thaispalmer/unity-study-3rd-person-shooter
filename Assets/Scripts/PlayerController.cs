using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    HealthController healthController;

    void Start()
    {
        healthController = gameObject.GetComponent<HealthController>();
    }

    private void OnCollisionEnter(Collision col)
    {
        float force = 3;
        if (col.gameObject.tag == "Enemy")
        {
            print(gameObject.name + " just hit " + col.gameObject.name);
            
            Vector3 direction = transform.position - col.transform.position;
            direction.Normalize();

            gameObject.GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.Impulse);

            if (healthController)
            {
                int damage = col.gameObject.GetComponent<EnemyController>().damage;
                healthController.Damage(damage);

                if (healthController.currentHealth == 0)
                {
                    // Kill the player character
                }
            }
        }
    }
}
