using UnityEngine;
using TMPro;

public class AddReview : MonoBehaviour
{
    [SerializeField] private TMP_Text reviewText;
    [SerializeField] int clientNum;

    void Start()
    {

        if (clientNum == 1)
        {
            reviewText.text = PlayerData.Instance.Reviews[0].ToString();
        }
        else if (clientNum == 2)
        {
            reviewText.text = PlayerData.Instance.Reviews[1].ToString();
        }
        else if (clientNum ==3)
        {
            reviewText.text = PlayerData.Instance.Reviews[2].ToString();
        }
        else
        {
            Debug.Log("Review index is wrong");
        }
    }

}
