using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private int _hitCount = 0;

    private void Update()
    {
        if (_hitCount >= 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet") || collision.CompareTag("EnemyBullet"))
        {
            _hitCount++;
        }

        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
