using UnityEngine;

public class Player : MonoBehaviour
{
    private float _walkSpeed = 5f;
    private float _runSpeed = 10f;
    private float _speed;
    private float _horizontalInput;
    private float _verticalInput;
    private Rigidbody2D _rb;
    private Vector2 _movementInput;
    private bool _isRunning = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        _speed = _walkSpeed;
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _movementInput.magnitude > 1 ? _movementInput.normalized * _speed : _movementInput * _speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            _isRunning = !_isRunning;
            _speed = _isRunning ? _runSpeed : _walkSpeed;
        }

        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        _movementInput = new Vector2(_horizontalInput, _verticalInput);
    }
}
