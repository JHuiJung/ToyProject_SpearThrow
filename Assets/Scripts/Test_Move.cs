using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Move : MonoBehaviour
{
    public Camera Player_Camera;
    public float speed = 8f;
    public float turnSpeed = 8.0f;
    float verical;
    private float xRotate, yRotate=0f;
    float horizon;

    // Start is called before the first frame update
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

    void Move()
    {

        this.transform.position += new Vector3(horizon * speed * Time.deltaTime, 0, verical * speed * Time.deltaTime);
    }
    void Camera_Move()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed *Time.deltaTime;
        // 현재 y축 회전값에 더한 새로운 회전각도 계산
        
        yRotate = Mathf.Clamp(yRotate + yRotateSize, -30, 30);
        // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed *Time.deltaTime;
        // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
        // Clamp 는 값의 범위를 제한하는 함수
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
        Player_Camera.transform.eulerAngles = new Vector3(xRotate, 180f+yRotate, 0);
        
    }
}
