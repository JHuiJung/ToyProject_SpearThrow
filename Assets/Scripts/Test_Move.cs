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
        // ���� y�� ȸ������ ���� ���ο� ȸ������ ���
        
        yRotate = Mathf.Clamp(yRotate + yRotateSize, -30, 30);
        // ���Ʒ��� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� ȸ���� �� ���(�ϴ�, �ٴ��� �ٶ󺸴� ����)
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed *Time.deltaTime;
        // ���Ʒ� ȸ������ ���������� -45�� ~ 80���� ���� (-45:�ϴù���, 80:�ٴڹ���)
        // Clamp �� ���� ������ �����ϴ� �Լ�
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        // ī�޶� ȸ������ ī�޶� �ݿ�(X, Y�ุ ȸ��)
        Player_Camera.transform.eulerAngles = new Vector3(xRotate, 180f+yRotate, 0);
        
    }
}
