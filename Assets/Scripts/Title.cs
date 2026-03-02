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

    private bool _isMuted;

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnOptionsClicked()
    {
        _playButton.gameObject.SetActive(false);
        _optionsButton.gameObject.SetActive(false);
        _quitButton.gameObject.SetActive(false);

        _muteButton.gameObject.SetActive(true);
        _backButton.gameObject.SetActive(true);
    }

    public void OnBackClicked()
    {
        _playButton.gameObject.SetActive(true);
        _optionsButton.gameObject.SetActive(true);
        _quitButton.gameObject.SetActive(true);

        _muteButton.gameObject.SetActive(false);
        _backButton.gameObject.SetActive(false);
    }

    public void ToggleMute()
    {
        if (!_isMuted)
        {
            _isMuted = true;

            _muteButton.gameObject.SetActive(false);
            _unmuteButton.gameObject.SetActive(true);
            AudioListener.volume = 0;
        }
        else
        {
            _isMuted = false;

            _muteButton.gameObject.SetActive(true);
            _unmuteButton.gameObject.SetActive(false);
            AudioListener.volume = 1;
        }
    }
}
