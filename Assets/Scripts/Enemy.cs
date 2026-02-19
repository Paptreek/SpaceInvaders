using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSound;
    public GameObject explosionSound;
    public ParticleSystem explosionEffect;

    private Rigidbody2D _rb;
    private float _moveSpeed = 20.0f;
    private float _shootTimer = 0.0f;
    private float _moveTimer = 1.0f;
    private float _updatedMoveTimer = 1.0f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        explosionEffect.transform.position = transform.position;
        FireBullet();
    }

    private void FixedUpdate()
    {
        _moveTimer -= Time.deltaTime;

        if (_moveTimer <= 0)
        {
            _rb.linearVelocityX = _moveSpeed;
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            _moveSpeed = -_moveSpeed;
            _updatedMoveTimer -= 0.1f;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.25f, 0);
        }
    }

    private void FireBullet()
    {
        _shootTimer -= Time.deltaTime;

        if (_shootTimer <= 0)
        {
            bullet.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, 0);
            bulletSound.GetComponent<AudioSource>().Play();
            Instantiate(bullet);
            _shootTimer = 5.0f;
        }
    }
}
