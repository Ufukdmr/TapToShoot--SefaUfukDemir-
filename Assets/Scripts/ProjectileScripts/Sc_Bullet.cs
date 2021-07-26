using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Bullet : Sc_Projectile
{
  
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="BrickCube")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward*force);                     
        }
    }

   
}
