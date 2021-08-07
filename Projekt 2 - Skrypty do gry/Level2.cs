using System.Collections;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    void OnTriggerEnter(Collider collision) //funkcja przekazuje informacje na temat kolizji 
    {
        if (collision.gameObject.name == "Sphere") //sprawdzamy czy to kula miała kolizję
        {
            string levelName = Application.loadedLevelName; //nazwa aktualnego poziomu
            Application.LoadLevel("Poziom 2"); //ładowanie poziomu

        }
    }
}
