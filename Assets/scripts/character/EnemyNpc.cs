using UnityEngine;

public class EnemyNpc : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Header("Movement Settings")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private bool moveOnX = false;
    [SerializeField] private bool moveOnY = false;
    [SerializeField] private float moveDistance = 3f; // Distance to move
    [SerializeField] private int _direction = 1;

    private Vector2 _startPosition;

    void Start()
    {
        _startPosition = transform.position; // Store original position
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();

    }

    void MoveEnemy()
    {
        Vector2 targetPosition = _startPosition;
        if (moveOnX) targetPosition.x += moveDistance * _direction;
        if (moveOnY) targetPosition.y += moveDistance * _direction;

        // Move the NPC
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if NPC has reached the target
        if (Mathf.Approximately(Vector2.Distance(transform.position, targetPosition), 0))
        {
            _direction *= -1; // Reverse direction
        }
    }


}
