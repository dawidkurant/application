using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelItem : MonoBehaviour
{

    public TextMesh textMesh;
    public string levelName;

    void Start()
    {
        textMesh.text = levelName;
    }

    void OnMouseDown()
    {
        Application.LoadLevel(levelName);
    }
}
