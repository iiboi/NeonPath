using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject losePanel;
    
    [Header("Score Texts")]
    [SerializeField] TextMeshProUGUI gameScoreText;
    [SerializeField] TextMeshProUGUI startBestScoreText;
    [SerializeField] TextMeshProUGUI loseBestScoreText;
    [SerializeField] TextMeshProUGUI loseCurrentScoreText;

    public static UIManager instance;

    private void Awake() 
    {
        instance = this;
    }

    private void Start() 
    {
        startPanel.SetActive(true);
        gamePanel.SetActive(false);
        losePanel.SetActive(false);
    }

    public void GameStartUI()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        losePanel.SetActive(false);
    }

    public void GameOverUI()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(false);
        losePanel.SetActive(true);
    }

    public void updateGameScore(int currentScore)
    {
        gameScoreText.text = currentScore.ToString();
    }
    public void updateBestScore(int bestScore)
    {
        startBestScoreText.text = "BEST SCORE: " + bestScore.ToString();
        loseBestScoreText.text = "BEST SCORE: " + bestScore.ToString();
    }

    public void UpdateLoseScore(int score)
    {
        if(loseCurrentScoreText != null)
        {
            loseCurrentScoreText.text = "SCORE: " + score.ToString();
        }
    }
}
