using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_Spear : Weapon
{
    float time_Charge = 1f;
    float _time = 0f;
    float _power = 15f;

    Vector3 emtPos = Vector3.zero;
    public override void Init()
    {
        base.Init();
        //Debug.Log("초기화 실행됨");
    }

    public override void Excute()
    {
        base.Excute();
        //Debug.Log("창업데이트 실행됨");

        //if (Input.GetMouseButtonDown(0))
        //{
        //    emtPos =  transform.position;
        //}
        
        if (Input.GetMouseButton(0))
        {
            _time += Time.deltaTime;
            transform.Translate(-1*Vector3.up * Time.deltaTime);

        }

        if(Input.GetMouseButtonUp(0))
        {
            //Debug.Log(_time);
            if (_time > time_Charge)
            {
                shoot();
            }
            _time = 0f;
            this.transform.localPosition = new Vector3(0.551f, -0.175f, 1.534f);
            
        }

    }

    public override void shoot()
    {
        base.shoot();
        Vector3 targetPos = GetTargetPos();
        if(targetPos == Vector3.zero) { return; }
        
        var shootObj = Instantiate(ShootObj);
        shootObj.transform.position =
        PlayerController.inst.transform.position + Vector3.up * 3f;

        if (_time > 2f) _time = 2f;

        shootObj.GetComponent<WeaponDummy>().Shoot(targetPos, _power * _time);
    }

    
}
