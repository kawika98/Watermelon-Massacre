using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public Transform playerPos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) )
            playerPos.position = playerPos.position + new Vector3(0, 0, speed);
        if (Input.GetKey(KeyCode.S) )
            playerPos.position = playerPos.position + new Vector3(0, 0, -speed);
        if (Input.GetKey(KeyCode.A) )
            playerPos.position = playerPos.position + new Vector3(-speed, 0, 0);
        if (Input.GetKey(KeyCode.D) )
            playerPos.position = playerPos.position + new Vector3(speed, 0, 0);
    }
}
