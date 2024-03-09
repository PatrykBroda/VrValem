using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float playerHealth = 100;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "FireProjectile")
        {
           // UpdateHealth()
        }
    }

    private void UpdateHealth(float dmg)
    {

    }
}
