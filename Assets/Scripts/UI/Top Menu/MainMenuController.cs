using UnityEngine;
using UnityEngine.SceneManagement;
 
public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void PlayGame() {
        SceneManager.LoadScene("Lvl1");
        SceneManager.UnloadSceneAsync("Mainmenu");
    }
 
    public void Options() 
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Back() 
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
 
    public void ExitGame() {
        Application.Quit();
    }
}