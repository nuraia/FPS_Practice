
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();
    public static ObjectPooler Instance;

    void Awake()
    {
        Instance = this;
    }
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    void Start()
    {
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }


    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    { 
        Debug.Log(tag);
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + "doesnot exist");
            return null;
        }
        GameObject ObjectToSpawn = poolDictionary[tag].Dequeue();
        ObjectToSpawn.gameObject.SetActive(true);
        ObjectToSpawn.transform.position = position;
        ObjectToSpawn.transform.rotation = rotation;
        IPooledObject pooledObj = ObjectToSpawn.GetComponent<IPooledObject>();
        if (pooledObj != null) pooledObj.OnObjectSpawn();
        //poolDictionary[tag].Enqueue(ObjectToSpawn);
        return ObjectToSpawn;
    }

}
