using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private GameObject _explosionSound;
    [SerializeField] private GameObject _moveSound;

    private Rigidbody2D _rb;
    private float _moveSpeed = 1.5f;
    private Vector3 _startingPos = new Vector3(11, 3.15f, 0);

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocityX = -_moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            // upon death:

            // start a 1 second deathTimer to allow the effects to play
            // disable renderer and collider
            // stop moveSound
            // play explosion sound and effect

            // once deathTimer hits 0:

            // start a 30 second spawnTimer
            // reset position
            // set speed to 0

            // once spawnTimer hits 0:

            // turn renderer and collider back on
            // turn moveSound on
            // set speed to 1.5f

            Reset();
        }
    }

    private void Reset()
    {
        transform.position = _startingPos;
    }
}
