using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{

    public Animator anim;
    public void Update()
    {
        if (!Cancelacion.iscancel)
        {
            Rotate();
            anim.speed = General.swordvelocity;
            //Debug.Log(anim.speed);
        }
        else
        {
            anim.speed = 0;
        }
        
    }
    public void Rotate()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.y));

        mousepos.z = transform.position.z;

        Vector3 dir = mousepos - transform.position;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,-angle));
    }
}
