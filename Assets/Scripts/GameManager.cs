using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuObj;
    [SerializeField] private GameObject _pauseManagerObj;
    [SerializeField] private GameObject _enemyGroupObj;
    [SerializeField] private GameObject _playerObj;
    [SerializeField] private GameObject _scoreObj;
    [SerializeField] private GameObject _gameAudio;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _highScoreText;
    [SerializeField] private TMP_Text _livesText;

    private EnemyGroup _enemyGroup;
    private PlayerController _player;

    private int _currentScore;

    private void Awake()
    {
        _enemyGroup = _enemyGroupObj.GetComponent<EnemyGroup>();
        _player = _playerObj.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            _pauseManagerObj.GetComponent<PauseMenu>().PauseGameAudio();
            Time.timeScale = 0;
            _pauseMenuObj.SetActive(true);
        }

        _currentScore = _scoreObj.GetComponent<Score>().CurrentScore;
        _scoreText.text = $"Score: {_currentScore:0000}";

        int _highScore = GetHighScore();
        _highScoreText.text = $"High Score: {_highScore:0000}";

        int remainingLives = _player.LivesRemaining;
        _livesText.text = $"Lives: {remainingLives}";

        if (_currentScore > _highScore)
        {
            SetHighScore();
        }

        CheckForGameOver();
    }

    private void SetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", _currentScore);
    }

    private int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }

    private void CheckForGameOver()
    {
        if (_player.LivesRemaining <= 0)
        {
            Debug.Log($"Game Over!");
        }

        if (_enemyGroup.GetEnemyCount() <= 0)
        {
            Debug.Log($"You Win!");
        }
    }
}
