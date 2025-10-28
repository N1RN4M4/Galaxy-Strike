using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    int score = 0;

    void increaseScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
    }
}

