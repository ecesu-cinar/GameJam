using System.Collections;
using UnityEngine;

public class Npc : MonoBehaviour
{
    
    [SerializeField] private int _stopsCount = 3;  // Number of stops (Set in Inspector)
    [SerializeField] private Vector2[] _waypoints; // Waypoints (Set manually in Unity)
    [SerializeField] private float _speed = 2f;    // Movement speed

    private int _currentWaypointIndex = 0;
    private Vector2 _startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startPosition = transform.position;

        if (_waypoints.Length == 0)
        {
            _waypoints = new Vector2[_stopsCount];
        }

        StartCoroutine(MoveNPC());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveNPC()
    {
        while (true)
        {
            // Move through each waypoint
            for (int i = 0; i < _waypoints.Length; i++)
            {
                yield return StartCoroutine(MoveToPosition(_waypoints[i]));
            }

            // Return to original position
            yield return StartCoroutine(MoveToPosition(_startPosition));
        }
    }

    IEnumerator MoveToPosition(Vector2 targetPosition)
    {
        while ((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
