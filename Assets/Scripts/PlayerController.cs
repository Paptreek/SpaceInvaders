using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSound;
    public GameObject explosionSound;
    public ParticleSystem explosionEffect;

    private Rigidbody2D _rb;
    private InputAction _moveAction;
    
    private Vector2 _moveValue;

    private float _moveSpeed = 5;
    private float _bulletTimer;
    
    
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        explosionEffect.transform.position = transform.position;
        _moveValue = _moveAction.ReadValue<Vector2>();
        _bulletTimer -= Time.deltaTime;

        if (Keyboard.current.spaceKey.isPressed && _bulletTimer <= 0)
        {
            bullet.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
            Instantiate(bullet);
            bulletSound.GetComponent<AudioSource>().Play();
            _bulletTimer = 1.0f;
        }
    }

    private void FixedUpdate()
    {
        _rb.linearVelocityX = _moveValue.x * _moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            explosionEffect.Play();
            explosionSound.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
