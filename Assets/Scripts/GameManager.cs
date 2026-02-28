using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _scoreObj;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _highScoreText;

    private int _currentScore;
    private int _highScore;

    private void Update()
    {
        _currentScore = _scoreObj.GetComponent<Score>().CurrentScore;
        _scoreText.text = $"Score: {_currentScore:0000}";
    }
}
