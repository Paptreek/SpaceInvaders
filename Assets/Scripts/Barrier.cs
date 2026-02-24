using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private int _hitCount = 0;
    [SerializeField] private GameObject _explosionSound;
    [SerializeField] private GameObject _explosionEffect;

    private void Update()
    {
        if (_hitCount >= 7)
        {
            Kill();
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
            Kill();
        }
    }

    private void Kill()
    {
        _explosionEffect.transform.position = transform.position;

        Destroy(gameObject);
        _explosionSound.GetComponent<AudioSource>().Play();
        _explosionEffect.GetComponent<ParticleSystem>().Play();
    }
}
