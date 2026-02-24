using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private GameObject _explosionSound;
    [SerializeField] private GameObject _explosionEffect;

    private float _timer = 1.0f;
    private bool _wasShot;

    private void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * _moveSpeed * Time.deltaTime);

        if (transform.position.x <= -11.0f)
        {
            Destroy(gameObject);
        }

        if (_wasShot)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                Destroy(gameObject);
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
        _wasShot = true;

        Renderer[] components = GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in components)
        {
            Destroy(renderer);
        }

        GetComponent<AudioSource>().Stop();
        _explosionSound.GetComponent<AudioSource>().Play();
        _explosionEffect.transform.position = transform.position;
        _explosionEffect.GetComponent<ParticleSystem>().Play();
    }
}
