using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private InputAction _moveAction;
    private float _moveSpeed = 5;
    private Vector2 _moveValue;
    
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _moveValue = _moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocityX = _moveValue.x * _moveSpeed;
    }
}
