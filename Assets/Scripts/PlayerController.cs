using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bulletSound;
    [SerializeField] private GameObject _explosionSound;
    [SerializeField] private ParticleSystem _explosionEffect;

    private Rigidbody2D _rb;
    private InputAction _moveAction;
    private Vector2 _moveValue;
    private float _moveSpeed = 3.5f;
    private float _bulletTimer;
    
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _explosionEffect.transform.position = transform.position;
        _moveValue = _moveAction.ReadValue<Vector2>();
        _bulletTimer -= Time.deltaTime;

        if (Keyboard.current.spaceKey.isPressed && _bulletTimer <= 0)
        {
            GameObject tempBullet = Instantiate(_bullet, new Vector2(transform.position.x, transform.position.y + 0.75f), transform.rotation);
            _bulletSound.GetComponent<AudioSource>().Play();
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
            _explosionEffect.Play();
            _explosionSound.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
