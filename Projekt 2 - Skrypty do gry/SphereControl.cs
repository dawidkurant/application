using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class SphereControl : MonoBehaviour
{
    int layer = 0; //określa na której warstwie znajduje się kula
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 3.2f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {
        Rigidbody rigidbody = transform.GetComponent<Rigidbody>(); //pobranie komponentu fizyki kuli

        Vector3 direction = Vector3.zero; //zmienna odpowiadająca kierunkowi

        if(Input.GetKey(KeyCode.UpArrow)) //jeśli przycisk strzałka w górę został naciśnięty
        {
            direction += -Vector3.forward;
            layer = 1;
        }

        if (Input.GetKey(KeyCode.DownArrow)) //jeśli przycisk strzałka w dół został naciśnięty
        {
            direction += Vector3.forward;
            layer = 0;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) //jeśli przycisk strzałka w lewo został naciśnięty
        {
            direction += -Vector3.left;
        }

        if (Input.GetKey(KeyCode.RightArrow)) //jeśli przycisk strzałka w prawo został naciśnięty
        {
            direction += Vector3.left;
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) //jeśli przycisk B przygotowanie do strzału
        {
            rigidbody.angularVelocity = Vector3.zero;

        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        

        rigidbody.AddTorque(direction * 2f); //*20f prędkość toczenia się kuli

        void changeLayer()
        {
            Vector3 position = rigidbody.position;
            position.z = layer * 2f - 2f;
            rigidbody.position = position;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        switch (collision.name)
        {
            case "OrbFioletowy":
                Score.scoreAmount += 1;
                Destroy(collision.gameObject);
                break;

            case "OrbCzerwony":
                Score.scoreAmount += 5;
                Destroy(collision.gameObject);
                break;

            case "OrbŻółty":
                Health.Heal(40f);
                Destroy(collision.gameObject);
                break;

            case "OrbZielony":
                Score.scoreAmount += 7;
                Destroy(collision.gameObject);
                break;

            case "OrbNiebieski":
                Destroy(collision.gameObject);
                break;

            case "OrbBiały":
                Health.Damage(20f);
                rb.AddForce(Vector3.up * 300);
                rb.AddForce(Vector3.left * 100);
                Destroy(collision.gameObject);
                break;
        }
    }

   
}
