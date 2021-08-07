using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger2 : MonoBehaviour
{
    void OnTriggerEnter(Collider collision) //funkcja przekazuje informacje na temat kolizji 
    {
        if (collision.gameObject.name == "Sphere") //sprawdzamy czy to kula miała kolizję
        {
            Health.Damage(10f);
            collision.gameObject.transform.position = GameManager.Instance.lastCheckPoint.position;
        }
    }
}
