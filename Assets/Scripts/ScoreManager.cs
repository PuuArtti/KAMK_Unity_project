using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; //Reference to the UI
    public int score = 0;
    public static int Hi_score = 0;
    public int Meat_ScoreTarget = 500;
    public int Meat_CurrentScore = 0;
    public TMP_Text HiscoreText;
    public GameObject Meat;
    public GameObject[] MeatSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreText(); //Show score on HUD
        UpdateHiScore(); //show hiscore
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore (int pointscore) 
    {
        score += pointscore; //Increase score
        UpdateScoreText();
        UpdateHiScore();
        UpdateMeatScore(100);

        if (Meat_CurrentScore >= Meat_ScoreTarget) 
        {
            SpawnMeat();
            resetMeatScore();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void UpdateHiScore() 
    {
        if (score > Hi_score)
        {
            HiscoreText.text = "HiScore:" +score.ToString();
        }
        else 
        { 
            return; 
        }
        
    }

    public void UpdateMeatScore(int meatscore) 
    {
        Meat_CurrentScore += meatscore;

    }
     void resetMeatScore()
    {
        Meat_CurrentScore = 0;
    }


    void SpawnMeat() 
    {
        int randomIndex = Random.Range(0, MeatSpawn.Length);
        GameObject chosenSpawnPoint = MeatSpawn[randomIndex];

        Instantiate(Meat, chosenSpawnPoint.transform.position, chosenSpawnPoint.transform.rotation);
    }
}

