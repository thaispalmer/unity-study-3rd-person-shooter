using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Hit " + other.name + "!");
        Destroy(gameObject);
    }
}
