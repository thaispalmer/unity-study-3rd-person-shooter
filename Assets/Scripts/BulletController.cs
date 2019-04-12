using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Hit " + other.name + "!");
        Destroy(gameObject);

        if (other.tag == "Enemy")
        {
            HealthController healthController = other.gameObject.GetComponent<HealthController>();
            if (healthController)
            {
                healthController.Damage(10);
                if (healthController.currentHealth > 0)
                {
                    return;
                }
                healthController.Destroy();
            }
            Destroy(other.gameObject);
            print("Destroyed!");
        }
    }
}
