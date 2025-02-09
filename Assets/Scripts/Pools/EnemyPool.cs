using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int poolSize;
    [SerializeField] List<GameObject> pool = new();
    [SerializeField] bool generateNewPool = true;


    void Start()
    {
        if (generateNewPool) CreatePool();
    }


    void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(enemyPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }


    public GameObject GetEnemyFromPool()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        //if pool dried up
        GameObject newObj = Instantiate(enemyPrefab);
        pool.Add(newObj);

        return newObj;
    }


}
