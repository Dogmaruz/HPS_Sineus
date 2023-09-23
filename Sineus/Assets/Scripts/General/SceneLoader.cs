using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public const string MAIN_MENU_SCENE_TITLE = "Menu";

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE_TITLE);
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("CityLevel");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
