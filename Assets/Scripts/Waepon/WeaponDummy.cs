using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class WeaponDummy : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    public void Shoot(Vector3 targetPos, float power)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            transform.LookAt(targetPos);
            transform.eulerAngles += Vector3.right * 90f; 
            rb.AddForce(targetPos.normalized * power, ForceMode.Impulse);
        }

    }

    public void Destroy_this()
    {
        Destroy(gameObject);
    }
}
