using UnityEngine;
using UnityEngine.SceneManagement;

public class DoneBtn : MonoBehaviour
{
    public string levelToLoad;
    [SerializeField] public int levelToLoadNum;

    public void CompleteLevel()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (GameManager.instance.IsOverBudget())
        {
            audioSource.Play();
        }
        else {
            int stylePointsAchieved = GameManager.instance.CurrentStylePoints;
            int requiredStylePoints = GameManager.instance.client.StylePointsGoal;
            if (stylePointsAchieved >= requiredStylePoints)
            {
                PlayerData.Instance.AddReview(GameManager.instance.client.GoodReview);
            }
            else
            {
                PlayerData.Instance.AddReview(GameManager.instance.client.BadReview);
            }
            PlayerData.Instance.AddScore(GameManager.instance.CurrentStylePoints);
            GameManager.instance.NewLevel(levelToLoadNum);
            ChangeLevel();
            //Invoke(nameof(ChangeLevel), 3f); 
        }//loads scene
    }

    public void ChangeLevel()
    {
        SceneManager.LoadScene(levelToLoad); //loads scene
    }

}


