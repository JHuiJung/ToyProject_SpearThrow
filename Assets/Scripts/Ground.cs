using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public static int Ground_number = 0;
    public int this_Ground_Number;
    // Start is called before the first frame update
    void Start()
    {
        this_Ground_Number = Ground_number;
        Ground_number++;
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
