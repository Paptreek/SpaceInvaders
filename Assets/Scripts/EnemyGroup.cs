using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private GameObject _alienLav;
    [SerializeField] private GameObject _alienOrchid;
    [SerializeField] private GameObject _alienTeal;
    [SerializeField] private GameObject _alienTurq;
    
    private List<Enemy> _enemies = new List<Enemy>();
    private List<GameObject> _enemyObjects = new List<GameObject>();
    private float _bulletTimer = 3.0f;

    public int NumberOfEnemiesKilled { get; private set; }

    private void Start()
    {
        _enemyObjects.Add(_alienLav);
        _enemyObjects.Add(_alienTurq);
        _enemyObjects.Add(_alienOrchid);
        _enemyObjects.Add(_alienTeal);

        int alien = 0;

        float spawnLocationX = -6;
        float spawnLocationY = -1;

        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 13; col++)
            {
                GameObject tempEnemy = Instantiate(_enemyObjects[alien], new Vector2(spawnLocationX, spawnLocationY), transform.rotation);
                _enemies.Add(tempEnemy.GetComponent<Enemy>());
                spawnLocationX += 1;
            }

            alien++;
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
                NumberOfEnemiesKilled++;
                Debug.Log(NumberOfEnemiesKilled);
            }
            
            if (enemy != null && enemy.GetComponent<Enemy>().NeedsToFlipDirection)
            {
                for (int i = 0; i < _enemies.Count; i++)
                {
                    if (_enemies[i] != null)
                    {
                        _enemies[i].GetComponent<Enemy>().FlipDirection();
                    }
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
