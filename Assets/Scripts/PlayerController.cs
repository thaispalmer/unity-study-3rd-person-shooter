using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        float force = 3;
        if (col.gameObject.tag == "Enemy")
        {
            print(gameObject.name + " just hit " + col.gameObject.name);
            
            Vector3 direction = transform.position - col.transform.position;
            direction.Normalize();

            gameObject.GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.Impulse);
        }
    }
}
