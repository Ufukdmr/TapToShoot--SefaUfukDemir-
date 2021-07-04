using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Explosion : Sc_Projectile
{
  public float explosionRange=5.0f;
    
    public float upForce;

public override void Throw(Vector3 dir)
   {
        transform.Translate(dir.normalized * speed*Time.deltaTime,Space.World);
   }
    void Detonate()
    {
        Vector3 expolisonPos=this.transform.position;
        Collider[] colliders=Physics.OverlapSphere(expolisonPos,explosionRange);
        foreach(Collider hit in colliders)
        {
            Rigidbody rigid=hit.GetComponent<Rigidbody>();
            if(rigid!=null&&!rigid.isKinematic)
            {
               hit.GetComponent<BoxCollider>().isTrigger=true;
               
                GameManager._Instance.DiscardColoredList(hit.gameObject);
                rigid.AddExplosionForce(force,expolisonPos,explosionRange,upForce,ForceMode.Impulse);

            }
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="BrickCube")
        {
            Detonate();
            
            GameManager._Instance.isThrowing=false;
            Destroy(this.gameObject);
        }
    }

}
