using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SimpleObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private Stack<GameObject> InactiveInstances = new Stack<GameObject>();

    public GameObject GetObject()
    {
        GameObject spawnedGameObject;

        if(InactiveInstances.Count > 0)
        {
            spawnedGameObject = InactiveInstances.Pop();    
        }
        else
        {
            spawnedGameObject = (GameObject)GameObject.Instantiate(prefab);

            PooledObject pooledObject = spawnedGameObject.AddComponent<PooledObject>();
            pooledObject.pool = this;
        }
        spawnedGameObject.SetActive(true);

        return spawnedGameObject;
    }
    public void ReturnObject(GameObject toReturn)
    {
        PooledObject pooledObject = toReturn.GetComponent<PooledObject>();

        if(pooledObject != null&&pooledObject.pool==this) 
        {
        toReturn.SetActive(false);  

            InactiveInstances.Push(toReturn);
         }
        else
        {
            Debug.LogWarning(toReturn.name + "was returned to pool it wasn't spawned from! Destroying.");
            Destroy(toReturn);
        }
    }
}
public class PooledObject:MonoBehaviour
{
    public SimpleObjectPool pool;
}
