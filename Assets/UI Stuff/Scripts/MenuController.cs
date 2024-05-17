using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("02Level1");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
