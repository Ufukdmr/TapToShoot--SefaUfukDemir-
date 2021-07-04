using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sc_Button : MonoBehaviour
{
    [SerializeField]
    public GameObject pre_Projectile;
    
    void Update()
    {
        if(GameManager._Instance.isFinish)
        {
            this.GetComponent<Button>().interactable=false;
        }
    }
}
