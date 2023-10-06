using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MinionAI : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 2f;
    public float searchRange = 5f;
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;
    private float nextAttackTime = 0f;
    private GameObject target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Find the nearest enemy.
        GameObject closestEnemy = FindClosestEnemy();

        // Check if an enemy was found.
        if (closestEnemy != null)
        {
            // Move towards the enemy.
            Vector2 moveDirection = (closestEnemy.transform.position - transform.position).normalized;
            rb.velocity = moveDirection * moveSpeed;

            // Check if the enemy is within attack range and the minion is ready to attack.
            if (Vector2.Distance(transform.position, closestEnemy.transform.position) <= attackRange && Time.time >= nextAttackTime)
            {
                //Attack the enemy.
               AttackEnemy(closestEnemy);
            }
        }
        else
        {
            // No enemy in range, stop moving.
            rb.velocity = Vector2.zero;
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject enemy in enemies)
        {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = enemy;
                distance = curDistance;
            }
        }
        return closest;
    }

    void AttackEnemy(GameObject enemy)
    {
        // Inflict damage, assuming the enemy has a component called 'EnemyHealth'
        EnemyStats enemyStats = enemy.GetComponent<EnemyStats>();
        if (enemyStats != null)
        {
            enemyStats.TakeDamage(25);
        }

        // Apply cooldown
        nextAttackTime = Time.time + attackCooldown;
    }
}

