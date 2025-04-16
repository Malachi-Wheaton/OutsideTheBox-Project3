using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;

    public GameObject pauseMenuUI;
    public GameObject winMenuUI;

    private bool isPaused = false;
    private bool hasWon = false;

    void Awake()
    {
        // Make this script globally accessible
        if (Instance == null)
            Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !hasWon)
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ShowWinScreen()
    {
        winMenuUI.SetActive(true);
        Time.timeScale = 0f;
        hasWon = true;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}


