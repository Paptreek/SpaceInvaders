using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private GameObject _scoreObject;

    private float _moveSpeed = 4.0f;

    public bool CollidedWithEnemy { get; private set; }

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
        if (collision.CompareTag("Enemy"))
        {
            CollidedWithEnemy = true;
            // add 100 points
        }

        if (collision.CompareTag("UFO"))
        {
            // add 1000 points
        }

        if (!collision.CompareTag("EnemyWall"))
        {
            Destroy(gameObject);
        }
    }
}
