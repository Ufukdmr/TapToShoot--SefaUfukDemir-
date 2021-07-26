using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    private GameObject selectedObject;
    [SerializeField]
    LayerMask shootable;

    GameObject Bullet;
   
    private static RaycastManager instance;

    public static RaycastManager _Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<RaycastManager>();
            }
            return instance;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, shootable))
            {
                selectedObject = hitInfo.collider.gameObject;     
                GameManager._Instance.GetTarget(selectedObject);          
                Bullet=ObjectPooler.Instance.ShootFromPool("Bullet",this.transform.rotation); 
               
             
            }
            
        }
           if(selectedObject!=null)
        {
            Bullet.GetComponent<Sc_Bullet>().Throw(selectedObject.transform.position-Bullet.transform.position);
        }
       

    }
}
