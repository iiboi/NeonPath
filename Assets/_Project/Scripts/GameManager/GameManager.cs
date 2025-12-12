using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] BallMovement ballMovement;
    int score = 0;
    int speedLevel = 1;

    public bool isGameOver = false;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void IncreaseScore()
    {
        score++;
        // Debug.Log($"Score: {score}");
        
        if (score % 50 == 0)
        {
            ballMovement.IncreaseSpeed();

            Debug.Log($"Speed Level: {speedLevel}");
            speedLevel++;
        }
    }

    public void GameOver()
    {
        if (isGameOver == true)
        {
            return;
        }

        isGameOver = true;

        Debug.Log($"Game Over!");
    }    
    
}
