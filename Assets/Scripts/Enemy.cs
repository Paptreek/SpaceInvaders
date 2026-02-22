using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSound;
    public GameObject explosionSound;
    public ParticleSystem explosionEffect;

    public bool NeedsToFlipDirection { get; private set; }

    private Rigidbody2D _rb;
    private bool _needsToMoveDown;
    private float _moveSpeed = 0.25f;
    private float _moveTimer = 1.0f;
    private float _updatedMoveTimer = 1.0f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        explosionEffect.transform.position = transform.position;
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
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            explosionEffect.Play();
            explosionSound.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log($"Wall");
            NeedsToFlipDirection = true;
        }
    }

    private void MoveDown()
    {
        _rb.MovePosition(new Vector2(transform.position.x, transform.position.y - 0.25f));
        _needsToMoveDown = false;
    }

    public void FireBullet()
    {
        bullet.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, 0);
        bulletSound.GetComponent<AudioSource>().Play();
        Instantiate(bullet);
    }

    public void FlipDirection()
    {
        _needsToMoveDown = true;
        NeedsToFlipDirection = false;

        _moveSpeed = -_moveSpeed;
        _updatedMoveTimer -= 0.1f;
    }
}
