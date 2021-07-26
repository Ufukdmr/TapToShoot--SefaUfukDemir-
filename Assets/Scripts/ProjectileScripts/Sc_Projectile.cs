using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Projectile : MonoBehaviour
{
    public float speed;
    public float force;
    public Rigidbody rigid;
    public Vector3 target;

    bool isShoot=false;
   
  
    public virtual void Throw(Vector3 dir)
    {   
         
        rigid.velocity=dir*speed;

    }

    void FixedUpdate()
    {
        if(this.gameObject.activeSelf)
        {
            Debug.Log(isShoot);
        }
      
    }

    public void Shoot(Vector3 dir)
    {
      
          target=dir;
          isShoot=true;
         
       
    }

    
    
}
