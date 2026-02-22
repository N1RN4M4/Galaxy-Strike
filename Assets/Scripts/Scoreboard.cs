using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{

    [SerializeField] TMP_Text scoreBoardText;
    int score = 0;

    public void increaseScore(int points)
    {
        score += points;
        scoreBoardText.text = score.ToString();
        // Debug.Log("Score: " + score);
    }

}
