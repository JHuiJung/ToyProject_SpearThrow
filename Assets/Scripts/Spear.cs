using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spear : MonoBehaviour
{
    
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,3f);
    }
    public void Throw( Vector3 Throw_Vector , float Throw_Power)
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {

            rb.AddForce(Throw_Vector.normalized * Throw_Power, ForceMode.Impulse);
        }
        
    }
    public void Destroy_this()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    
}
