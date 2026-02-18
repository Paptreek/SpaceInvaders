using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSound;

    private Rigidbody2D _rb;
    private InputAction _moveAction;
    
    private Vector2 _moveValue;

    private float _moveSpeed = 5;
    private float _bulletTimer = 0;
    
    
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _moveValue = _moveAction.ReadValue<Vector2>();
        _bulletTimer -= Time.deltaTime;

        if (Keyboard.current.spaceKey.isPressed && _bulletTimer <= 0)
        {
            bullet.transform.position = new Vector3(transform.position.x, -3.75f, 0);
            Instantiate(bullet);
            bulletSound.GetComponent<AudioSource>().Play();
            _bulletTimer = 0.5f;
        }
    }

    private void FixedUpdate()
    {
        _rb.linearVelocityX = _moveValue.x * _moveSpeed;
    }
}
