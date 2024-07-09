using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button soundConfigButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Slider soundSlider;

    [Header("Sound Settings")]
    [SerializeField] private AudioSource backgroundMusic;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        soundConfigButton.onClick.AddListener(ToggleSoundConfig);
        exitButton.onClick.AddListener(ExitGame);
        soundSlider.onValueChanged.AddListener(SetVolume);

        soundSlider.gameObject.SetActive(false); // Hide the slider initially
        soundSlider.value = backgroundMusic.volume; // Initialize slider value
    }

    private void StartGame()
    {
        // Replace "GameScene" with the name of your game scene
        SceneManager.LoadScene("Scene");
    }

    private void ToggleSoundConfig()
    {
        soundSlider.gameObject.SetActive(!soundSlider.gameObject.activeSelf); // Toggle slider visibility
    }

    private void SetVolume(float volume)
    {
        backgroundMusic.volume = volume;
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
