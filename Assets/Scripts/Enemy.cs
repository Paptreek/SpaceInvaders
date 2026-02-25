using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bulletSound;
    [SerializeField] private GameObject _explosionSound;
    [SerializeField] private GameObject _explosionEffect;

    private Rigidbody2D _rb;
    private bool _needsToMoveDown;
    private float _moveSpeed = 0.25f;
    private float _moveTimer = 1.0f;
    private float _updatedMoveTimer = 1.0f;

    public bool IsDead { get; private set; }
    public bool NeedsToFlipDirection { get; private set; }

    public void FlipDirection()
    {
        _needsToMoveDown = true;
        NeedsToFlipDirection = false;

        _moveSpeed = -_moveSpeed;
        _updatedMoveTimer -= 0.05f;
    }

    public void FireBullet()
    {
        Instantiate(_bullet, new Vector2(transform.position.x, transform.position.y - 0.5f), transform.rotation);
        _bulletSound.GetComponent<AudioSource>().Play();
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _moveTimer -= Time.deltaTime;

        if (_moveTimer <= 0)
        {
            _rb.MovePosition(new Vector2(transform.position.x + _moveSpeed, transform.position.y));

            if (_needsToMoveDown)
            {
                MoveDown();
            }

            _moveTimer = _updatedMoveTimer;
        }
        else
        {
            _rb.linearVelocityX = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            IsDead = true;
            _explosionSound.GetComponent<AudioSource>().Play();
            _explosionEffect.GetComponent<ParticleSystem>().Play();
            DestroyComponents();
            Destroy(gameObject, 0.75f);
        }

        if (collision.CompareTag("EnemyWall"))
        {
            NeedsToFlipDirection = true;
        }
    }

    private void DestroyComponents()
    {
        Destroy(GetComponent<Renderer>());
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(GetComponent<Enemy>());
    }

    private void MoveDown()
    {
        _rb.MovePosition(new Vector2(transform.position.x, transform.position.y - 0.25f));
        _needsToMoveDown = false;
    }
}
