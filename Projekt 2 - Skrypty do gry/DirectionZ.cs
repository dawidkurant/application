using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionZ : MonoBehaviour
{
    public bool fowardDirection = true; //kierunek w którym strzałka ma przesuwać obiekt (false - ruch po osi z, true - w przeciwnym)

    void OnTriggerStay(Collider collision) //wywołuje się w momencie kiedy kula będzie próbowała iść w innym kierunku niż strzałka
    {
        GameObject thing = collision.gameObject; //pobieramy obiekt, który wszedł w interakcję
        Rigidbody rigidbody = thing.GetComponent<Rigidbody>(); //pobieramy komponent fizyki naszego obiektu 
        Vector3 velocity = rigidbody.velocity; //pobieramy aktualną prędkość naszego obiektu

        if (fowardDirection)
        {
            velocity.z = 8f; //ustawienie prędkości
        }

        else
        {
            velocity.z = -8f;
        }

        rigidbody.velocity = velocity; //aktualizacja prędkości fizycznej naszego obiektu 
    }
}
