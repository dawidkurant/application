using System.Collections;
using UnityEngine;

public class Respawn: MonoBehaviour
{
    public GameObject ballPrefab;
    public Camera cameraPrefab;
    public Light lightPrefab;

    public GameObject gameOverBase;
    public GameObject levelName;


    void Start()
    {
        GameObject sphere = GameObject.Instantiate(ballPrefab); //generowanie kuli na planszy
        sphere.name = "Sphere"; //zmiana nazwy
        sphere.transform.position = transform.position + Vector3.up * 2f; //położenie kuli na planszy respawn

        Camera camera = GameObject.Instantiate(cameraPrefab); //generowanie camery na planszy
        CameraControler cameraControler = camera.GetComponent<CameraControler>(); //wydobywamy skrypt podążania kamery za kulą
        cameraControler.sphere = sphere.transform; //kamera podąża za kulą

        Light light = GameObject.Instantiate(lightPrefab); // generowanie światła na planszy

        //light.color = Color.white; //nadanie koloru światłu
        //light.intensity = 0.5f; //nadanie intensywności światłu
        //RenderSettings.ambientLight = Color.white * 0.7f;  //ustawienie światła ambientowego

        GameObject.Instantiate(gameOverBase);
        GameObject.Instantiate(levelName);

    }


    void Update()
    {
        
    }
}
