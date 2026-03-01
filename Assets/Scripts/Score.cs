using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject _enemyGroup;
    [SerializeField] private GameObject _ufo;

    public int CurrentScore { get; private set; }

    private void Update()
    {
        CalculateScore();
    }

    private void CalculateScore()
    {
        int enemyPoints = _enemyGroup.GetComponent<EnemyGroup>().NumberOfEnemiesKilled * 100;
        int ufoPoints = _ufo.GetComponent<UFO>().NumberKilled * 1000;

        CurrentScore = enemyPoints + ufoPoints;
    }
}
