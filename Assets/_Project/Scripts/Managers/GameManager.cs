using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] BallMovement ballMovement;
    [SerializeField] UIManager uIManager;
    int score = 0;
    int speedLevel = 1;

    const string SAVE_KEY = "BestScore";

    public bool isGameOver = false;
    public bool isGameStarted = false;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;

        isGameStarted = false;
    }

    private void Start() 
    {
        int savedScore = PlayerPrefs.GetInt(SAVE_KEY, 0);

        uIManager.updateBestScore(savedScore);

    }

    public void IncreaseScore()
    {
        score++;
        // Debug.Log($"Score: {score}");

        uIManager.updateGameScore(score);
        
        if (score % 50 == 0)
        {
            ballMovement.IncreaseSpeed();

            Debug.Log($"Speed Level: {speedLevel}");
            speedLevel++;
        }
    }

    public void GameStart()
    {
        isGameStarted = true;

        uIManager.GameStartUI();
        ballMovement.StartMove();
    }
    public void GameOver()
    {
        if (isGameOver == true)
        {
            return;
        }

        isGameOver = true;

        int bestScore = PlayerPrefs.GetInt(SAVE_KEY, 0);

        if (score > bestScore)
        {
            PlayerPrefs.SetInt(SAVE_KEY, score);

            bestScore = score;
        }

        uIManager.updateBestScore(bestScore);
        uIManager.UpdateLoseScore(score);

        uIManager.GameOverUI();
    }    
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
