using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance=this;   
    }
    void Start()
    {
        poolDictionary=new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool=new Queue<GameObject>();
            for(int i=0; i<pool.size;i++)
            {
                GameObject obj=Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

             poolDictionary.Add(pool.tag,objectPool);
        }

       
    }

    public GameObject ShootFromPool(string tag,Quaternion rotation)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            return null;
        }
        GameObject objectToShoot=poolDictionary[tag].Dequeue();
        objectToShoot.SetActive(true);
        objectToShoot.transform.position=this.transform.position;
        objectToShoot.transform.rotation=rotation;

        poolDictionary[tag].Enqueue(objectToShoot);

        return objectToShoot;
    }

}
