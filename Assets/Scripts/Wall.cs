using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isCreate = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isCreate)
        {
            Debug.Log("����!");
        }
        else
        {
            Debug.Log("����!");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isCreate)
        {
            Debug.Log("����!");
        }
        else
        {
            Debug.Log("����!");
        }
    }
}
