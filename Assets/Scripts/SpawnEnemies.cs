using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemies;
    public Transform[] spawnPoints;
    public float spawnTime = 5f;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnTime) 
        {
            SpawnEnemy();
            timer = 0f;
        }
        
    }
    void SpawnEnemy() 
    {
        Transform spawnpoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemies, spawnpoint.position, spawnpoint.rotation);
    }
}
