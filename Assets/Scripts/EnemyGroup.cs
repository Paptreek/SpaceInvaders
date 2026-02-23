using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();
    [SerializeField] private GameObject _enemy;

    private float _bulletTimer = 3.0f;

    private void Start()
    {
        float spawnLocation = -7;

        for (int i = 0; i < 15; i++)
        {
            GameObject tempEnemy = Instantiate(_enemy, new Vector2(spawnLocation, 0), transform.rotation);
            _enemies.Add(tempEnemy.GetComponent<Enemy>());

            spawnLocation += 1;
        }
    }

    private void Update()
    {
        foreach (Enemy enemy in _enemies.ToList())
        {
            if (enemy == null)
            {
                _enemies.Remove(enemy);
            }

            if (enemy != null && enemy.GetComponent<Enemy>().NeedsToFlipDirection)
            {
                for (int i = 0; i < _enemies.Count; i++)
                {
                    _enemies[i].GetComponent<Enemy>().FlipDirection();
                }
            }
        }

        RandomEnemyFireBullet();
    }

    private void RandomEnemyFireBullet()
    {
        _bulletTimer -= Time.deltaTime;

        int randomEnemy = Random.Range(0, _enemies.Count);
        float randomTimer = Random.Range(1.0f, 3.0f);

        if (_enemies.Count > 0 && _bulletTimer <= 0)
        {
            _enemies[randomEnemy].FireBullet();
            _bulletTimer = randomTimer;
        }
    }
}
