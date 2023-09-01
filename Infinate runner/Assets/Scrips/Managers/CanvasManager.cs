using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class CanvasManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer sfxMixer;

    [Header("Button")]
    public Button startButton;
    public Button pauseButton;
    public Button creditsButton;
    public Button howToButton;
    public Button creditsBackButton;
    public Button howToBackButton;
    public Button settingsButton;
    public Button backToPauseMenuButton;
    public Button quitButton;
    public Button returnToMenuButton;
    public Button returnToGameButton;

    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject loseMenu;
    public GameObject creditsMenu;
    public GameObject howToMenu;
    public GameObject settingsMenu;
    public GameObject pauseMenu;

    [Header("Text")]
    public Text musicSliderText;
    public Text sfxSliderText;

    [Header("Slider")]
    public Slider musicVolSlider;
    public Slider sfxVolSlider;

    public void StartGame()
    {
        SceneManager.LoadScene("Level");
        Time.timeScale = 1;
    }

    public void StartLose()
    {
        loseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    void ShowSettingsMenu()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void BackToPauseMenu()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Credits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void HowTo()
    {
        mainMenu.SetActive(false);
        howToMenu.SetActive(true);
    }

    public void CreditsBack()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void HowToBack()
    {
        mainMenu.SetActive(true);
        howToMenu.SetActive(false);
    }

    public void ShowMainMenu()
    {
        if (SceneManager.GetActiveScene().name == "Level")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    void OnMusicSliderValueChanged(float value)
    {
        if (musicSliderText)
        {
            musicSliderText.text = value.ToString();
            audioMixer.SetFloat("MusicVol", value - 80);
        }
    }

    void OnSfxSliderValueChanged(float value)
    {
        if (sfxSliderText)
        {
            sfxSliderText.text = value.ToString();
            audioMixer.SetFloat("SFXVol", value - 80);
        }
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    void GameOver()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("GameOver");
    }

    // Start is called before the first frame update
    void Start()
    {
        if (startButton)
            startButton.onClick.AddListener(StartGame);

        if (pauseButton)
            pauseButton.onClick.AddListener(PauseGame);

        if(backToPauseMenuButton)
            backToPauseMenuButton.onClick.AddListener(BackToPauseMenu);

        if (howToButton)
            howToButton.onClick.AddListener(HowTo);

        if (creditsButton)
            creditsButton.onClick.AddListener(Credits);

        if (howToBackButton)
            howToBackButton.onClick.AddListener(HowToBack);

        if (creditsBackButton)
            creditsBackButton.onClick.AddListener(CreditsBack);

        if (settingsButton)
            settingsButton.onClick.AddListener(ShowSettingsMenu);

        if (quitButton)
            quitButton.onClick.AddListener(QuitGame);

        if (returnToMenuButton)
            returnToMenuButton.onClick.AddListener(ShowMainMenu);

        if (returnToGameButton)
            returnToGameButton.onClick.AddListener(ResumeGame);

        if (musicVolSlider)
        {
            musicVolSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
            float mixerValue;
            audioMixer.GetFloat("MusicVol", out mixerValue);
            musicVolSlider.value = mixerValue + 80;
        }

        if (sfxVolSlider)
        {
            sfxVolSlider.onValueChanged.AddListener(OnSfxSliderValueChanged);
            float mixerValue;
            audioMixer.GetFloat("SFXVol", out mixerValue);
            sfxVolSlider.value = mixerValue + 80;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                pauseMenu.SetActive(!pauseMenu.activeSelf);
                PauseGame();
            }
        }        
    }
}
