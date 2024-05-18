using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{   
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject ingameUI;
    public void StartGame()
    {
        SceneManager.LoadScene("02Level1");
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        ingameUI.SetActive(false);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        ingameUI.SetActive(true);
        Time.timeScale = 1;
    }
    
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("01MainMenu");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
