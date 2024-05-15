using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private int Player1Score = 0; // Changed type to int for score counting
    private int Player2Score = 0; // Changed type to int for score counting
    public TMP_Text Player1ScoreText;
    public TMP_Text Player2ScoreText;
    public int scoreToReach;

    public int lastPlayerScored = 0; // Variable to track the last player who scored

    public void Player1CurrentScore()
    {
        Player1Score++;
        Player1ScoreText.text = Player1Score.ToString();
        lastPlayerScored = 1; // Update last player who scored to player 1
        CheckScore();
    }
    public void Player2CurrentScore()
    {
        Player2Score++;
        Player2ScoreText.text = Player2Score.ToString();
        lastPlayerScored = 2; // Update last player who scored to player 2
        CheckScore();
    }
    private void CheckScore()
    {
        if (Player1Score == scoreToReach || Player2Score == scoreToReach)
        {
            SceneManager.LoadScene(2);
        }
    }
}
