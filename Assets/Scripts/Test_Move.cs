using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Test_Move : MonoBehaviour
{
    public Vector3 Ground_Transform;
    public Camera Player_Camera;
    public GameObject Spear;
    public GameObject Prefab_Spears;
    public Transform Throw_start;
    public float speed = 8f;
    public float turnSpeed = 8.0f;
    float verical;
    float horizon;
    float xRotate, yRotate;
    RaycastHit hit;
    Ray mouseRay;
    bool isShoot;
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
        Shoot();
    }
    void Shoot()
    {
        if(isShoot) {
            Spear.transform.eulerAngles = Player_Camera.transform.eulerAngles + new Vector3(60f, 0, 0);

            GameObject s = Instantiate(Prefab_Spears, Throw_start.position,Player_Camera.transform.rotation);
            if(s != null)
            {
                s.AddComponent<Rigidbody>();
                Spear sp = s.GetComponent<Spear>();
                if(sp != null)
                {

                    sp.Throw((Ground_Transform - Throw_start.position), 10f);
                }
                
                
            }
            
        }
        else
        {
            Spear.transform.eulerAngles = Player_Camera.transform.eulerAngles + new Vector3(90f, 0, 0);
        }
    }
    void Move_input()
    {
        verical = Input.GetAxis("Vertical");
        horizon = Input.GetAxis("Horizontal");
        isShoot = Input.GetMouseButtonDown(0);
        
        
    }
    void Move() {
        this.transform.position += new Vector3(horizon * speed * Time.deltaTime, 0, verical * speed * Time.deltaTime);
    }
    

    void Camera_Move()
    {
        
        if(Input.GetKey(KeyCode.Q))
        {
            float yRotateSize = -1*turnSpeed * Time.deltaTime;
            yRotate = Mathf.Clamp(yRotate + yRotateSize, -30, 30);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            float yRotateSize = turnSpeed * Time.deltaTime;
            yRotate = Mathf.Clamp(yRotate + yRotateSize, -30, 30);
        }
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime;

        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);





        Player_Camera.transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

    }

    void Find_GroundTransfrom()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(mouseRay,out hit, Mathf.Infinity, LayerMask.GetMask("Ground"))){
            Ground_Transform = hit.point;
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


