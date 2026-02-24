using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _ufo;

    private float _spawnTimer = 10.0f;

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;

        if (_spawnTimer <= 0)
        {
            Instantiate(_ufo, new Vector2(11, 3.15f), transform.rotation);
            _spawnTimer = 30.0f;
        }
    }
}
