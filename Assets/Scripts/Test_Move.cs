using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Test_Move : MonoBehaviour
{
    public Camera Player_Camera;
    public float speed = 8f;
    public float turnSpeed = 8.0f;
    float verical;
    float horizon;
    float xRotate, yRotate;
    public Vector3 tr;
    RaycastHit hit;
    Ray mouseRay;
    void Start()
    {
        mouseRay = new Ray();
    }

    // Update is called once per frame
    void Update()
    {
        Move_input();
        Move();
        Camera_Move();
        Find_GroundTransfrom();
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
        

        yRotate = Mathf.Clamp(yRotate + yRotateSize, -180, 180);
        
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime;
        
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        
        Player_Camera.transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

    }

    void Find_GroundTransfrom()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(mouseRay,out hit, Mathf.Infinity, LayerMask.GetMask("Ground"))){
            tr = hit.point;
        }
        
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(
        mouseRay.origin,
        mouseRay.direction * hit.distance,
        Color.red);
    }


}


