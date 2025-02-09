using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    #region Static Singleton

    public static Pool Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Another instance of Pool exists! Destroying this Instance");
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    #endregion


    [SerializeField] EnemyPool enemyPool;


    public GameObject GetEnemyFromPool()
    {
        return enemyPool.GetEnemyFromPool();
    }


    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

}
