using UnityEngine;
using UnityEditor;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public float armor = 20;
    public float maxArmor = 100;
    public int magicArmor = 10;
    public int moveSpeed = 5;
    public TextMeshProUGUI healthText;

    private void Start()
    {
        healthText.text = health.ToString();
    }

    public void TakeDamage(int damage)
    {
        // Apply damage after considering armor and magic armor.
        int finalDamage = Mathf.RoundToInt( damage * (1 - (armor / maxArmor)));
        health -= finalDamage;
        healthText.text = health.ToString();

        // Check for game over condition (if health reaches zero).
        if (health <= 0)
        {
            EditorApplication.isPlaying = false;
        }
    }

    // You can also add other stats like damage, speed, etc.
}

