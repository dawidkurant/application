using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
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

        if (Input.GetKey(KeyCode.UpArrow)) //jeśli przycisk strzałka w górę został naciśnięty
        {
            direction += -Vector3.left;
        }

        if (Input.GetKey(KeyCode.DownArrow)) //jeśli przycisk strzałka w dół został naciśnięty
        {
            direction += Vector3.left;

        }

        if (Input.GetKey(KeyCode.LeftArrow)) //jeśli przycisk strzałka w lewo został naciśnięty
        {
            direction += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.RightArrow)) //jeśli przycisk strzałka w prawo został naciśnięty
        {
            direction += -Vector3.forward;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        rigidbody.AddForce(3.5f * direction); //*20f prędkość toczenia się kuli

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
        }
    }


}
