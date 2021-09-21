using System.Collections;
using UnityEngine;

public class EscapeToMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("menu");
        }
    }
}
