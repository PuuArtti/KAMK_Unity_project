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
        //Hi_score = PlayerPrefs.GetInt("HiScore",Hi_score);
        UpdateScoreText(); //Show score on HUD
        UpdateHiScore(); //show hiscore
        score = 0;
        Debug.Log("HiScore Loaded: " + Hi_score);

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
        if (score >= Hi_score)
        {
            Hi_score = score;
            
            HiscoreText.text = "HiScore:" + score.ToString();
            PlayerPrefs.SetInt("HiScore", Hi_score);
        }
        else 
        {
            HiscoreText.text = "HiScore:" + score.ToString();
            Hi_score = PlayerPrefs.GetInt("HiScore", Hi_score);
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
        if (MeatSpawn.Length == 0)
        {
            Debug.LogWarning("MeatSpawn array is empty!");
            return;
        }
        int randomIndex = Random.Range(0, MeatSpawn.Length);
        GameObject chosenSpawnPoint = MeatSpawn[randomIndex];

        Instantiate(Meat, chosenSpawnPoint.transform.position, chosenSpawnPoint.transform.rotation);
    }
}

