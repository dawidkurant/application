using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGame : MonoBehaviour
{
    void OnTriggerEnter(Collider collision) //funkcja przekazuje informacje na temat kolizji 
    {
        if (collision.gameObject.name == "Sphere") //sprawdzamy czy to kula miała kolizję
        {
            GameObject block = collision.gameObject;
            Rigidbody rb = block.GetComponent<Rigidbody>();
            Health.Damage(20f);
            rb.AddForce(Vector3.up * 300);
            rb.AddForce(Vector3.left * 100);

        }
    }
}
