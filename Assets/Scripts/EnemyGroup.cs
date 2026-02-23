using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();
    [SerializeField] private GameObject _enemy;

    private float _bulletTimer = 3.0f;

    private void Start()
    {
        float spawnLocationX = -6;
        float spawnLocationY = 0;

        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 13; col++)
            {
                GameObject tempEnemy = Instantiate(_enemy, new Vector2(spawnLocationX, spawnLocationY), transform.rotation);
                _enemies.Add(tempEnemy.GetComponent<Enemy>());
                spawnLocationX += 1;
            }

            spawnLocationX = -6;
            spawnLocationY += 1;
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

            if (enemy != null && !enemy.GetComponent<Enemy>().IsDead && enemy.GetComponent<Enemy>().NeedsToFlipDirection)
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
