using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; //Reference to the UI
    public int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreText(); //Show score on HUD
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore (int pointscore) 
    {
        score += pointscore; //Increase score
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}

