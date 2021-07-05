using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Brick : MonoBehaviour
{
    
    public bool isShootable;
    [SerializeField]
    private Material[] mat_Bricks;
    [SerializeField]
    private float rigidMass=0.5f;
     
    public void Walling(int a)
    {
        if(a==1)
        {
            isShootable=true;

            ChangeColor();          
            Rigidbody rigid=new Rigidbody();           
            rigid=this.gameObject.AddComponent<Rigidbody>();
            rigid.mass=rigidMass;
            this.gameObject.layer=8;
            GameManager._Instance.AddColoredList(this.gameObject);
           
        }
        else
        {
            isShootable=false;
        }       

    }

    public void ChangeColor()
    {
        int k =Random.Range(1,mat_Bricks.Length);
        this.GetComponent<Renderer>().material=mat_Bricks[k];
    }

   
}
