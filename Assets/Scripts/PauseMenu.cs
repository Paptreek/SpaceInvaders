using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _quitButton;

    [SerializeField] private Button _muteButton;
    [SerializeField] private Button _unmuteButton;
    [SerializeField] private Button _backButton;

    public void OnOptionsClicked()
    {
        _resumeButton.gameObject.SetActive(false);
        _optionsButton.gameObject.SetActive(false);
        _quitButton.gameObject.SetActive(false);

        if (AudioListener.volume == 1)
        {
            _muteButton.gameObject.SetActive(true);
            _muteButton.Select();
        }
        else
        {
            _unmuteButton.gameObject.SetActive(true);
            _unmuteButton.Select();
        }

        _backButton.gameObject.SetActive(true);
    }

    public void OnBackClicked()
    {
        _resumeButton.gameObject.SetActive(true);
        _optionsButton.gameObject.SetActive(true);
        _quitButton.gameObject.SetActive(true);

        _resumeButton.Select();

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
            _unmuteButton.Select();
            AudioListener.volume = 0;
        }
        else
        {
            _unmuteButton.gameObject.SetActive(false);
            _muteButton.Select();
            _muteButton.gameObject.SetActive(true);
            AudioListener.volume = 1;
        }
    }

    public void QuitGame()
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

    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        _pauseMenu.SetActive(false);
    }

    private void Awake()
    {
        _resumeButton.Select();
    }
}
