using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Bomb : Sc_Explosion
{

    public override void Detonate()
    {
        Vector3 expolisonPos = this.transform.position;
        Collider[] colliders = Physics.OverlapSphere(expolisonPos, ExplosionRange);
        foreach (Collider hit in colliders)
        {
            Rigidbody rigid = hit.GetComponent<Rigidbody>();
            if (rigid != null && !rigid.isKinematic)
            {
                hit.GetComponent<BoxCollider>().isTrigger = true;

                GameManager._Instance.DiscardColoredList(hit.gameObject);
                rigid.AddExplosionForce(force, expolisonPos, ExplosionRange, UpForce, ForceMode.Impulse);

            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BrickCube")
        {
            Detonate();

            GameManager._Instance.isThrowing = false;
            Destroy(this.gameObject);
        }
    }
}
