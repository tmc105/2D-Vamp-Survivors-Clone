using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform player;
    public float moveSpeed = 2f; // Adjust this speed as needed.
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;
    private float nextAttackTime;
    private PlayerStats playerStats;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerStats = player.GetComponent<PlayerStats>();
    }

    void Update()
    {
        // Move towards the player.
        Vector2 moveDirection = (player.position - transform.position).normalized;
        rb.velocity = moveDirection * moveSpeed;

        // Check if the player is within attack range and can attack.
        if (Vector2.Distance(transform.position, player.position) <= attackRange && Time.time >= nextAttackTime)
        {
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {

        // Inflict damage to the player.
        playerStats.TakeDamage(25);

        // Set the cooldown for the next attack.
        nextAttackTime = Time.time + attackCooldown;
    }
}


