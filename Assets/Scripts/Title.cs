using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _quitButton;

    [SerializeField] private Button _muteButton;
    [SerializeField] private Button _unmuteButton;
    [SerializeField] private Button _backButton;

    private float _timer = 0.25f;
    private bool _hasStarted;

    public void StartGame()
    {
        _hasStarted = true;
    }

    public void OnOptionsClicked()
    {
        _playButton.gameObject.SetActive(false);
        _optionsButton.gameObject.SetActive(false);
        _quitButton.gameObject.SetActive(false);

        if (AudioListener.volume == 1)
        {
            _muteButton.gameObject.SetActive(true);
        }
        else
        {
            _unmuteButton.gameObject.SetActive(true);
        }

        _backButton.gameObject.SetActive(true);
    }

    public void OnBackClicked()
    {
        _playButton.gameObject.SetActive(true);
        _optionsButton.gameObject.SetActive(true);
        _quitButton.gameObject.SetActive(true);

        _muteButton.gameObject.SetActive(false);
        _unmuteButton.gameObject.SetActive(false);
        _backButton.gameObject.SetActive(false);
    }

    public void ToggleMute()
    {
        if (AudioListener.volume == 1)
        {
            _unmuteButton.gameObject.SetActive(true);
            _muteButton.gameObject.SetActive(false);
            AudioListener.volume = 0;
        }
        else
        {
            _muteButton.gameObject.SetActive(true);
            _unmuteButton.gameObject.SetActive(false);
            AudioListener.volume = 1;
        }
    }

    private void Update()
    {
        if (_hasStarted)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                SceneManager.LoadScene("Game");
            }
        }
    }
}
