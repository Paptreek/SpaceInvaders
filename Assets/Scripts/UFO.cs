using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEffectObj;
    [SerializeField] private GameObject _explosionSoundObj;
    [SerializeField] private GameObject _moveSoundObj;

    private Rigidbody2D _rb;
    private AudioSource _moveSound;
    private AudioSource _explosionSound;
    private ParticleSystem _explosionEffect;

    private bool _isActive;
    private bool _wasJustKilled;

    private float _moveSpeed = 0.0f;
    private float _deathTimer = 1.0f;
    private float _spawnTimer = 3.0f;

    private Vector3 _startingPos = new Vector3(11, 3.15f, 0);

    public int NumberKilled { get; private set; }


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _moveSound = _moveSoundObj.GetComponent<AudioSource>();
        _explosionSound = _explosionSoundObj.GetComponent<AudioSource>();
        _explosionEffect = _explosionEffectObj.GetComponent<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocityX = -_moveSpeed;
    }

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;

        _explosionEffectObj.transform.position = transform.position;

        if (_spawnTimer <= 0 && !_isActive)
        {
            Activate();
        }

        if (transform.position.x <= -11.0f)
        {
            Deactivate();
        }

        if (_wasJustKilled)
        {
            _deathTimer -= Time.deltaTime;

            if (_deathTimer <= 0)
            {
                Deactivate();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Kill();
        }
    }

    private void Kill()
    {
        _deathTimer = 1.0f;
        _wasJustKilled = true;
        NumberKilled++;

        GetComponent<Renderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        _moveSound.Stop();
        _explosionSound.Play();
        _explosionEffect.Play();
        
        _moveSpeed = 0;
    }

    private void Deactivate()
    {
        transform.position = _startingPos;
        
        _moveSound.Stop();

        _spawnTimer = 3.0f;
        _isActive = false;
        _wasJustKilled = false;
        _moveSpeed = 0;
    }

    private void Activate()
    {
        GetComponent<Renderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;

        _moveSound.Play();

        _isActive = true;
        _moveSpeed = 1.5f;
    }
}
