using UnityEngine;
using UnityEngine.SceneManagement;

public class DoneBtn : MonoBehaviour
{
    [SerializeField] private string levelToLoad;
    [SerializeField] private int levelToLoadNum;

    public void CompleteLevel()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (GameManager.instance.IsOverBudget())
        {
            audioSource.Play(); //warning sfx
        }
        else
        {
            //check how many style points you have right now
            int stylePointsAchieved = GameManager.instance.CurrentStylePoints;
            //check how stylish the client requires
            int requiredStylePoints = GameManager.instance.client.StylePointsGoal;
            //if you are above or equal, you can add a good review
            if (stylePointsAchieved >= requiredStylePoints)
            {
                PlayerData.Instance.AddReview(GameManager.instance.client.GoodReview);
            }
            else //bad review
            {
                PlayerData.Instance.AddReview(GameManager.instance.client.BadReview);
            }
            //track the score
            PlayerData.Instance.AddScore(GameManager.instance.CurrentStylePoints);
            //reset the style points and budget to the next client for the next level
            GameManager.instance.NewLevel(levelToLoadNum);
            //load next level
            ChangeLevel();
        }
    }

    public void ChangeLevel()
    {
        SceneManager.LoadScene(levelToLoad); //loads scene
    }

}


