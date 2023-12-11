using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage = 10;
    public GameObject ShootObj;

    

    public virtual void Init() { }
    public virtual void shoot() { }
    public virtual void Excute() 
    {

    }
    // Start is called before the first frame update
    public Vector3 GetTargetPos()
    {
        Ray mouseRay;
        RaycastHit hit;
        Vector3 targetPos = Vector3.zero;

        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            targetPos = hit.point;
        }

        return targetPos;
    }
    public void Destroy_this()
    {
        Destroy(gameObject);
    }
}
