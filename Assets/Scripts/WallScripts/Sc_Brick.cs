using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Brick : MonoBehaviour
{
    
    public bool isShootable;
    [SerializeField]
    private Material[] mat_Cubes;
     
    public void Walling(int a)
    {
        if(a==1)
        {
            isShootable=true;

            ChangeColor();          
            this.GetComponent<Rigidbody>().isKinematic=false;
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
        int k =Random.Range(1,mat_Cubes.Length);
        this.GetComponent<Renderer>().material=mat_Cubes[k];
    }

   
}
