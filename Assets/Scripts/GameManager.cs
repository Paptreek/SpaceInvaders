using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuObj;
    [SerializeField] private GameObject _uiManagerObj;
    [SerializeField] private GameObject _gameOverPanelObj;
    [SerializeField] private GameObject _enemyGroupObj;
    [SerializeField] private GameObject _playerObj;
    [SerializeField] private GameObject _scoreObj;
    [SerializeField] private GameObject _gameAudio;

    [SerializeField] private GameObject _victoryTextObj;
    [SerializeField] private GameObject _gameOverTextObj;

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
            _uiManagerObj.GetComponent<uiManager>().PauseGameAudio();
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
        if (_player.LivesRemaining <= 0 || _enemyGroup.EnemyHasTouchedFloor)
        {
            _gameOverPanelObj.gameObject.SetActive(true);
            _gameOverTextObj.gameObject.SetActive(true);
        }

        if (_enemyGroup.GetEnemyCount() <= 0)
        {
            _gameOverPanelObj.gameObject.SetActive(true);
            _victoryTextObj.gameObject.SetActive(true);
            _playerObj.SetActive(false);
        }
    }
}
