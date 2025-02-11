using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPool : MonoBehaviour
{
    [System.Serializable]
    class PowerupTypePool
    {
        public PowerupType powerupType;
        public GameObject powerupPrefab;
        public int poolSize;
        public List<GameObject> pool = new();
        public bool generateNewPool = true;
    }

    [SerializeField] List<PowerupTypePool> powerupTypePool = new();

    void Start()
    {
        foreach (PowerupTypePool pool in powerupTypePool)
        {
            if (pool.generateNewPool)
            {
                CreatePool(pool);
            }
        }
    }


    void CreatePool(PowerupTypePool powerupType)
    {
        for (int i = 0; i < powerupType.poolSize; i++)
        {
            GameObject obj = Instantiate(powerupType.powerupPrefab);
            obj.SetActive(false);
            powerupType.pool.Add(obj);
        }
    }


    public GameObject GetPowerupFromPool(PowerupType type)
    {
        foreach (PowerupTypePool pool in powerupTypePool)
        {
            if (pool.powerupType == type)
            {
                foreach (GameObject obj in pool.pool)
                {
                    if (!obj.activeInHierarchy)
                    {
                        obj.SetActive(true);
                        return obj;
                    }
                }

                //if pool dried up
                GameObject newObj = Instantiate(pool.powerupPrefab);
                pool.pool.Add(newObj);

                return newObj;
            }
        }

        return null;
    }


}
