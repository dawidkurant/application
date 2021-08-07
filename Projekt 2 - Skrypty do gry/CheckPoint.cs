using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider collision) //funkcja przekazuje informacje na temat kolizji 
    {
        if (collision.gameObject.name == "Sphere") //sprawdzamy czy to kula miała kolizję
        {
            GameManager.Instance.lastCheckPoint = transform;
        }
    }
}
