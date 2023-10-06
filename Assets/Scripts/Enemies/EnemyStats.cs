using System;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private GameObject xpObject;
    public int health = 100; // Set the default health value.

    public void TakeDamage(int damage)
    {
        health -= damage; // Reduce health by the 'damage' value.

        // If health is less than or equal to 0, destroy the GameObject.
        if (health <= 0)
        {
            DropXP();
            Destroy(gameObject);
        }
    }

    private void DropXP()
    {
        Instantiate(xpObject);
    }
}
