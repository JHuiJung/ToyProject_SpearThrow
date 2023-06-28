using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLR : MonoBehaviour
{
    public Transform s1, s2;
    Vector3 startPos, endPos;
    // Start is called before
    // the first frame update
    LineRenderer lr;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        startPos = s1.position;
        endPos = s2.position;

        Vector3 center = (startPos + endPos)*0.5f;

        center.y *= 0.5f;

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
