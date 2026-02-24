using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float _moveSpeed = 4.0f;

    private void Update()
    {
        transform.Translate(new Vector3(0, _moveSpeed, 0) * Time.deltaTime);

        if (transform.position.y > 5.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Enemy") || collision.CompareTag("Barrier") || collision.CompareTag("EnemyBullet"))
        //{
            Destroy(gameObject);
        //}
    }
}
