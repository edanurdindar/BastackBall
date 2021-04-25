using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
   
    public GameObject targetBall;
    private float speed = 2.2f;

    public void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, targetBall.transform.position.y + 4.0f, transform.position.z), speed * Time.deltaTime);
    }    
}

