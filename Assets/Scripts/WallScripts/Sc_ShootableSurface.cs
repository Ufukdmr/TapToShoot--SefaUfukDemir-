using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_ShootableSurface : MonoBehaviour
{
    public int columnCount, rowCount, shootableObjCount;
    public GameObject pre_Brick;
    public virtual void Start()
    {
        BuildWall();
    }



    public virtual void BuildWall()
    {

    }
    public virtual Vector3 BrickPos(int k, int j)
    {
        throw new NotImplementedException();
    }
}
