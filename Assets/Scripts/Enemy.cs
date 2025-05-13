using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
[RequireComponent(typeof(BoxCollider2D))]

public class Enemy : MonoBehaviour
{
    //Speed of movement
    public float speed = 100f;
    public float health = 10F;
    public List<Transform> points;
    //The int value for the next point index
    public int nextID = 0;
    //The value that applies to ID for changing
    public int idChangeValue = 1;
    Health Health;
    public GameObject player;
    public int pointscore = 100;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootInterval = 2f;

    private float timeSinceLastShot = 0f;
    private bool IsFacingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Enemy>();
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= shootInterval)
        {
            Shoot();
            timeSinceLastShot = 0f;
        }
        MoveToNextPoint();

    }

    private void Reset()
    {
        Init();
    }

    void Init() 
    {
        //Make Box collider trigger
        GetComponent<BoxCollider2D>().isTrigger = true;

        //create Root object
        GameObject root = new GameObject(name + "_Root");

        //Reset position of Root to Enemy Object
        root.transform.position = transform.position;

        //Set enemy object as child of root
        transform.SetParent(root.transform);


        //Create waypoint object
        GameObject waypoints = new GameObject("Waypoints");

        //Reset waypoints position to root
        waypoints.transform.position = root.transform.position;



        //Make waypoints object child of root
        waypoints.transform.SetParent(root.transform);

        //Create two points (gameobject) 
        GameObject p1 = new GameObject("Point1"); 
        GameObject p2 = new GameObject("Point2"); 

        //Make two points children of waypoint object
        p1.transform.SetParent(waypoints.transform);
        p2.transform.SetParent(waypoints.transform);

        // reset their position to waypoints objects
        p1.transform.position = waypoints.transform.position + new Vector3 (5, 0, 0);        
        p2.transform.position = waypoints.transform.position + new Vector3(-5, 0, 0);
        
        //Init points list then add the points to it
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);


    }

    void MoveToNextPoint() 
    
    {
        
        //Get the next point transform
        Transform goalPoint = points[nextID];

        //Flip the enemy transform to look into the point's direction
        if (goalPoint.transform.position.x > transform.position.x)
        {
            IsFacingRight = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            IsFacingRight = false;
            transform.localScale = new Vector3(1, 1, 1); 
        }

        //Move the enemy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed*Time.deltaTime);

        //Check the distance between enemy and goal point to trigger next point
        if (Vector2.Distance(transform.position, goalPoint.position) < 1f) 
        {
            //Check if we are at the end of the line (make the change -1)
            if (nextID == points.Count - 1)
                idChangeValue = -1;

            //Check if we are at the start of the line (make the change +1)
            if (nextID == 0)
                idChangeValue = 1;

            //Apply the change on the nextID
            nextID += idChangeValue;
        
        }



    }

   


    public void TakeDamage() 
    {
        health -= 1f;
        

        if (health <= 0f) 
        {
            Die();
        }

      
    }
    public void Die() 
    { //Disable Enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        FindAnyObjectByType<ScoreManager>().AddScore(pointscore);
        Destroy(gameObject);
    
    
    
    }

    void Shoot() 
    {
        //Spawn the bullet
        GameObject projectile = Instantiate (projectilePrefab, firePoint.position, firePoint.rotation);

        //Where is the enemy facing
        Vector2 shootDirection = IsFacingRight ? Vector2.right : Vector2.left;

        //Launch the bullet
        projectile.GetComponent<Projectile>().Launch(shootDirection);
    }
}
