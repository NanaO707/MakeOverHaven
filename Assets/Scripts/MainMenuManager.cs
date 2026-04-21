using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string levelToLoad;

    public void PlayGame()
    {
        SceneManager.LoadScene(levelToLoad); //loads scene
    }

    public void ResetGame()
    {
       GameManager.instance.DestroyGameManager(); //destroy the game manager because it is a dont destroy on load
       SceneManager.LoadScene("MainMenu"); //loads main menu
    }

    public void QuitGame()
    {
        Application.Quit(); //quits game
    }

}
