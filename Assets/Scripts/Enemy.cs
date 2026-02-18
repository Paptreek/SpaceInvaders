using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosionSound;
    public ParticleSystem explosionEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            explosionEffect.Play();
            explosionSound.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
