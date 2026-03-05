using UnityEngine;

public class Laser : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _moveSpeed = -4.5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rb.linearVelocityY = _moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor") || collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
