using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float moveSpeed = 1.5f;

    public GameObject obstaclePrefab;
    [SerializeField] private bool isMove;
    [SerializeField] private bool isLeft;
    [SerializeField] private bool isRight;

    public float spawnX = 4.0f;
    public float spawnY = 0.5f;
    public float spawnZ = 0f;

   

    Vector3 spawnPos = Vector3.zero;

    private void Start()
    {
       
        isMove = true;
    }
    void Update()
    {
        if (Ball.obstacleCount < 5)
        {
            ObstacleMove();
        }
    }

    void ObstacleMove()
    {
         if (isMove)
         {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0f, transform.position.y, transform.position.z), moveSpeed * Time.deltaTime);
         }
    }
     
    void SpawnObstacle()
    {
        int randomValue = Random.Range(0, 2);

       
            if (randomValue == 1)
            {
                isRight = true;
                var right = Instantiate(obstaclePrefab, transform.position + new Vector3(spawnX, 0.52f, 0), Quaternion.identity);
            }
            else
            {
                isLeft = true;
                var left = Instantiate(obstaclePrefab, transform.position + new Vector3(-spawnX, 0.52f, 0), Quaternion.identity);
            }
       }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
             isMove = false;
             SpawnObstacle();                  
        }
        
    }
}
