using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreAmount;
    public Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreAmount = 0;
    }

    void Update()
    {
        scoreText.text = "Score: " + scoreAmount;
    }
}
