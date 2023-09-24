using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public const string MAIN_MENU_SCENE_TITLE = "Menu";

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(MAIN_MENU_SCENE_TITLE);
    }

    public void StartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("CityLevel");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
