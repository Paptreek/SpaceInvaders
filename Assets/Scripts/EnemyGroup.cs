using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyGroup : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();

    private float _timer = 3.0f;

    private void Update()
    {
        foreach (GameObject enemy in enemies.ToList())
        {
            if (enemy == null)
            {
                enemies.Remove(enemy);
            }

            if (enemy != null && enemy.GetComponent<Enemy>().NeedsToFlipDirection)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].GetComponent<Enemy>().FlipDirection();
                }
            }
        }

        RandomEnemyShoot();
    }

    private void RandomEnemyShoot()
    {
        _timer -= Time.deltaTime;

        int random = Random.Range(0, enemies.Count);

        if (_timer <= 0)
        {
            enemies[random].GetComponent<Enemy>().FireBullet();

            _timer = 5.0f;
        }
    }
}
