using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * _moveSpeed * Time.deltaTime);

        if (transform.position.x <= -11.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
        }
    }
}
