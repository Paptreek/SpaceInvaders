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
    private Vector3 _startingPos = new Vector3(0, -4.25f, 0);

    private float _moveSpeed = 3.5f;
    private float _bulletTimer;
    private float _respawnTimer = 1.0f;
    private bool _isDead;

    public int LivesRemaining { get; private set; } = 3;
    
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

        if (_isDead)
        {
            _respawnTimer -= Time.deltaTime;

            if (_respawnTimer <= 0)
            {
                Respawn();
            }
        }

        if (Keyboard.current.spaceKey.isPressed && _bulletTimer <= 0 && !_isDead)
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
            _isDead = true;
            LivesRemaining--;

            _moveSpeed = 0;
            
            _explosionEffect.Play();
            _explosionSound.GetComponent<AudioSource>().Play();

            GetComponent<Renderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void Respawn()
    {
        if (_isDead && _respawnTimer <= 0)
        {
            _isDead = false;

            _moveSpeed = 3.5f;

            transform.position = _startingPos;

            GetComponent<Renderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;

            _respawnTimer = 1.0f;
        }
    }
}
