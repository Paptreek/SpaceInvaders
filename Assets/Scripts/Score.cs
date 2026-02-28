using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject _enemyGroup;
    [SerializeField] private GameObject _ufo;

    private float _timer = 1.0f;

    public int CurrentScore { get; private set; }

    private void Update()
    {
        CalculateScore();

        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            Debug.Log(CurrentScore);
            _timer = 1.0f;
        }
    }

    private void CalculateScore()
    {
        int enemyPoints = _enemyGroup.GetComponent<EnemyGroup>().NumberOfEnemiesKilled * 100;
        int ufoPoints = _ufo.GetComponent<UFO>().NumberKilled * 1000;

        CurrentScore = enemyPoints + ufoPoints;
    }
}
