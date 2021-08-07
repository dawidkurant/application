using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        switch (collision.name)
        {
            case "ROBOT":
                Score.scoreAmount += 3;
                Destroy(collision.gameObject);
                break;
        }
    }
}
