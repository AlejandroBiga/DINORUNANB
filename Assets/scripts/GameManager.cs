using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text BestScoreText;

    private int score;
    private float timer;
    private int bestScore;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    void Update()
    {
        UpdateScore();
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);

        
        if (score > bestScore)
        {
            bestScore = score;
            
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }

        // Actualizamos el texto del mejor puntaje
        BestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    private void UpdateScore()
    {
        int scorePerSeconds = 10;

        timer += Time.deltaTime;
        score = (int)(timer * scorePerSeconds);
        ScoreText.text = string.Format("{0:00000}", score);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}