using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLR : MonoBehaviour
{
    public GameObject draw_Position_obj;
    public Transform s1;
    Vector3 startPos;
    public Vector3 endPos;
    public bool isDraw { get; set; }
    Test_Move tm;
    // Start is called before
    // the first frame update
    LineRenderer lr;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
        tm = GameObject.FindGameObjectWithTag("Player").GetComponent<Test_Move>();
        lr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
       
            startPos = s1.position;
            endPos = tm.Ground_Transform;

            Vector3 center = (startPos + endPos) * 0.5f;

            center.y -= 100f;

            startPos -= center;
            endPos -= center;

            for (int i = 0; i < lr.positionCount; i++)
            {
                Vector3 point = Vector3.Slerp(startPos, endPos, i / (float)(lr.positionCount - 1));
                point += center;
                lr.SetPosition(i, point);
            }
        draw_Position_obj.SetActive(lr.enabled);
        draw_Position_obj.transform.position = tm.Ground_Transform;

        
        
        
    }
    public void set_LR(bool b)
    {
        if (b)
        {
            lr.enabled = true;
        }
        else
        {
            lr.enabled = false;
        }
    }
}
