using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Bullet : Sc_Projectile
{
   
   public override void Throw(Vector3 dir)
   {
        transform.Translate(dir.normalized * speed*Time.deltaTime,Space.World);
        
   }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="BrickCube")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward*force);
            GameManager._Instance.DiscardColoredList(collision.gameObject);
            GameManager._Instance.isThrowing=false;
            
            Destroy(this.gameObject);
            
        }
    }

   
}
