using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1"); 
    }


    public void OpenLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }


    public void OpenInstructions()
    {
        SceneManager.LoadScene("Instruction");
    }


    public void OpenCredits()
    {
        SceneManager.LoadScene("Credit");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }


    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}


