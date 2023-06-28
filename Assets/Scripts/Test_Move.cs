using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Test_Move : MonoBehaviour
{
    public Camera Player_Camera;
    public float speed = 8f;
    public float turnSpeed = 8.0f;
    float verical;
    private float xRotate, yRotate, xRotateMove, yRotateMove;
    float horizon;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move_input();
        Move();
        Camera_Move();
    }
    void Move_input()
    {
        verical = Input.GetAxis("Vertical");
        horizon = Input.GetAxis("Horizontal");

    }
    void Move() {
        this.transform.position += new Vector3(horizon * speed * Time.deltaTime, 0, verical * speed * Time.deltaTime);
    }
    

    void Camera_Move()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;
        

        yRotate = Mathf.Clamp(yRotate + yRotateSize, -30, 30);
        
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime;
        
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        
        Player_Camera.transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

    }


}


