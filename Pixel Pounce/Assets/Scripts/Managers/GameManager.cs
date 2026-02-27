using JetBrains.Annotations;
using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
   public static GameManager Instance;

     int currentScore = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    private void Start()
    {
        UpdateScoreUI(); // Set initial score to 0 on screen
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreUI();

    }

    public void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = currentScore.ToString();
        }
    }
}
