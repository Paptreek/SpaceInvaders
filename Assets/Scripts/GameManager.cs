using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _scoreObj;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _highScoreText;

    private int _currentScore;
    private int _highScore;

    private void Update()
    {
        _currentScore = _scoreObj.GetComponent<Score>().CurrentScore;
        _scoreText.text = $"Score: {_currentScore:0000}";

        _highScore = GetHighScore();
        _highScoreText.text = $"High Score: {_highScore:0000}";

        if (_currentScore > _highScore)
        {
            SetHighScore();
        }
    }

    private void SetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", _currentScore);
    }

    private int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }
}
