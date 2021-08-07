using System.Collections;
using UnityEngine;

public class LevelName : MonoBehaviour
{
    public TextMesh textMesh; //komponent wyświetlający tekst


    void Start()
    {
        string levelName = Application.loadedLevelName; //pobieramy nazwę aktualnego poziomu 
        textMesh.text = levelName; //przypisujemy nazwę aktualnego poziomu

    }
}
