using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject projectile;
    [SerializeField]
    GameObject SpawnPos;
    GameObject target;
    Vector3 dir;

    public bool isFinish=false;

    List<GameObject> coloredBricks=new List<GameObject>();
  

   public bool isThrowing=false;

    private static GameManager instance;

    public static GameManager _Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
   
    void FixedUpdate()
    {
       if(isThrowing)
       {
            projectile.GetComponent<Sc_Projectile>().Throw(dir);
       }
         
        
    }

    void Update()
    {
        if(coloredBricks.Count==0)
        {
            isFinish=true;
        }
    }
    public void GetProjectile(GameObject Projectile)
    {       
        if(Projectile!=null)
        {          
            if(projectile!=Projectile)
            {
                Destroy(projectile);
            }
            projectile=Instantiate(Projectile,SpawnPos.transform.position,Projectile.transform.rotation);
           
        }
    }
    public void GetTarget(GameObject Target)
    {
        target=Target;
        dir = target.transform.position - SpawnPos.transform.position;
        TapToShoot();
    }

    public void TapToShoot()
    {
        if(target!=null&&projectile!=null)
        {                              
             isThrowing=true;  
             foreach(GameObject coloredBrick in coloredBricks)
             {
                 coloredBrick.GetComponent<Sc_Brick>().ChangeColor();
             }                    
        }
      
    }

    public void AddColoredList(GameObject coloredBrick)
    {
        coloredBricks.Add(coloredBrick);
    }
    public void DiscardColoredList(GameObject coloredBrick)
    {
        coloredBricks.Remove(coloredBrick);
         StartCoroutine(DestroyBrick(coloredBrick));
    }

     IEnumerator DestroyBrick(GameObject Brick)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(Brick);
    }

}
