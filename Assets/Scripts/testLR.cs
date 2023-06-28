using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLR : MonoBehaviour
{
    public Transform s1;
    Vector3 startPos;
    public Vector3 endPos;
    Test_Move tm;
    // Start is called before
    // the first frame update
    LineRenderer lr;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.startWidth = 0.01f;
        lr.endWidth = 0.01f;
        tm = GameObject.FindGameObjectWithTag("Player").GetComponent<Test_Move>();
    }

    // Update is called once per frame
    void Update()
    {
        startPos = s1.position;
        endPos = tm.Ground_Transform;

        Vector3 center = (startPos + endPos)*0.5f;

        center.y -= 100f;

        startPos -= center;
        endPos -= center;

        for(int i = 0; i < lr.positionCount; i++)
        {
            Vector3 point = Vector3.Slerp(startPos, endPos, i/(float)(lr.positionCount-1));
            point += center;
            lr.SetPosition(i, point);
        }
    }
}
