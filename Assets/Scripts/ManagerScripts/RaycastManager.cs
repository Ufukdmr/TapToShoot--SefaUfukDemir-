using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    public GameObject selectedObject;
    [SerializeField]
    LayerMask shootable;
   
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
              
               selectedObject=null;
            }
        }

    }
}
