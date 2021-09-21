using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{

    public bool rightDirection = true; //kierunek w którym strzałka ma przesuwać obiekt (false - ruch po osi x, true - w przeciwnym)

    private CharacterController controller;


    void OnTriggerStay(Collider collision) //wywołuje się w momencie kiedy kula będzie próbowała iść w innym kierunku niż strzałka
    {
        GameObject thing = collision.gameObject; //pobieramy obiekt, który wszedł w interakcję
        Rigidbody rigidbody = thing.GetComponent<Rigidbody>(); //pobieramy komponent fizyki naszego obiektu 
        Vector3 velocity = rigidbody.velocity; //pobieramy aktualną prędkość naszego obiektu
        /* controller = thing.GetComponent<CharacterController>();
         * Vector3 relativeForward = transform.TransformDirection(Vector3.forward); 
        float moveSpeed = 50f;*/

        if (rightDirection)
        {
            //controller.Move(relativeForward * moveSpeed * Time.deltaTime); //ustawienie prędkości
            velocity.x = 8f;
        }

        else
        {
            //controller.Move(relativeForward * moveSpeed * Time.deltaTime);
            velocity.x = -8f;
        }

        rigidbody.velocity = velocity; //aktualizacja prędkości fizycznej naszego obiektu 
    }
}
