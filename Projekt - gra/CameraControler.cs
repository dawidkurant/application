using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Transform sphere;

    void Update()
    {
        Vector3 vector = new Vector3(-2f, 2f, 0); //-5f

        Rigidbody rigidbody = sphere.GetComponent<Rigidbody>();
        //float velocity = rigidbody.velocity.sqrMagnitude; //oddalanie się kamery gdy kula przyśpiesza, sqrMagnitude - prędkość kuli
        //vector = vector * (1f+velocity/250); //to przez co podzielone zależy od oddalenia i przybliżenia

        Vector3 newPosition = sphere.position + vector; //kamera podąża za kulą 

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime*2f); //płynność kamery
        transform.LookAt(sphere); //kamera patrzy w punkt centralny kuli
    }
}
