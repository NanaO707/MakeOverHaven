using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string levelToLoad;

    public void PlayGame()
    {
        SceneManager.LoadScene(levelToLoad); //loads scene
    }

    public void QuitGame()
    {
        Application.Quit(); //quits game
    }

}
