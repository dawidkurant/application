using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text healthText;
    public Image healthBar;

    static float health, maxHealth = 100;
    float lerpSpeed;

    void Start()
    {
        health = maxHealth;
    }

   
    void Update()
    {
        healthText.text = "Health: " + health + "%";
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed);
    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        healthBar.color = healthColor;
    }

    public static void Damage(float damagePoints)
    {
        if (health > 0)
        {
            health -= damagePoints;
        }

        if (health == 0)
        {
            Application.LoadLevel("Menu");
        }
    }

    public static void Heal(float healingPoints)
    {
        if (health < maxHealth)
        {
            health += healingPoints;
        }
    }
}
