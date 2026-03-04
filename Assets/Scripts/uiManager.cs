using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _gameAudio;

    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _quitButton;

    [SerializeField] private Button _muteButton;
    [SerializeField] private Button _unmuteButton;
    [SerializeField] private Button _backButton;

    private float _timer = 0.25f;

    public bool HasQuit { get; set; }

    public void OnOptionsClicked()
    {
        _resumeButton.gameObject.SetActive(false);
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
        _resumeButton.gameObject.SetActive(true);
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
            _muteButton.gameObject.SetActive(false);
            _unmuteButton.gameObject.SetActive(true);
            AudioListener.volume = 0;
        }
        else
        {
            _unmuteButton.gameObject.SetActive(false);
            _muteButton.gameObject.SetActive(true);
            AudioListener.volume = 1;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        UnpauseGameAudio();
        _pauseMenu.SetActive(false);
    }

    public void PauseGameAudio()
    {
        AudioSource[] audioSources = _gameAudio.GetComponentsInChildren<AudioSource>();

        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Pause();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void UnpauseGameAudio()
    {
        AudioSource[] audioSources = _gameAudio.GetComponentsInChildren<AudioSource>();

        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.UnPause();
        }
    }

    private void QuitGame()
    {
        SceneManager.LoadScene("Title");

        if (Time.timeScale < 1)
        {
            Time.timeScale = 1;
        }

        if (AudioListener.pause == true)
        {
            AudioListener.pause = false;
        }
    }

    private void Update()
    {
        if (HasQuit)
        {
            _timer -= Time.unscaledDeltaTime;

            if (_timer <= 0)
            {
                QuitGame();
            }
        }
    }
}
