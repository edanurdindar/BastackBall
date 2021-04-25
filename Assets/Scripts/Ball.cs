using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private Rigidbody ballRb;
    public float jumpForce;
    public float gravityModifier;

    public static int obstacleCount;
    public Text scoreText;
    int scoreCount;

    public GameObject floatingText;
    

    [SerializeField] bool isGround;
    [SerializeField] bool isMove;

    public static Ball Instance;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        obstacleCount = 0;
        
        isMove = true;
        ballRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        BallMove();
    }

    void BallMove()
    {
        if (Input.GetMouseButtonDown(0) && isMove)
        {       
            if (obstacleCount < 5)
            {  
                ballRb.AddForce(Vector3.up * 1.5f * jumpForce, ForceMode.Impulse);
                isMove = false;
            }
        }
    }

private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Camera.main.GetComponent<CameraManager>().MoveCamera();
            obstacleCount++;
            scoreCount += 3;
            scoreText.text = scoreCount.ToString();
            isMove = true;
            FloattingTextPrefabs();
        }       
    }

    void FloattingTextPrefabs()
    {
        var offset = new Vector3(0f, 1.0f, 0f);
        Instantiate(floatingText, transform.position + offset, Quaternion.identity, transform);

    }
}
