using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Explosion : Sc_Projectile
{
    public float ExplosionRange { get; set; }=5.0f;

    public float UpForce { get; set; }

    
    public virtual void Detonate()
    {
       
    }

}
