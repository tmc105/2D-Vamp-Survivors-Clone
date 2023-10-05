using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerMove : MonoBehaviour
{
    private PlayerStats playerStats;
    private Vector2 targetPosition;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        targetPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, playerStats.moveSpeed*Time.deltaTime);    

    }
    
}
