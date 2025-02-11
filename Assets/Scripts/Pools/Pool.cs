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
    [SerializeField] PowerupPool powerupPool;

    [SerializeField] GameObject bossEnemy;

    [SerializeField] int enemiesKilled;

    public GameObject GetEnemyFromPool()
    {
        return enemyPool.GetEnemyFromPool();
    }


    public GameObject GetPowerupFromPool()
    {
        PowerupType type = (PowerupType)Random.Range(0, System.Enum.GetValues(typeof(PowerupType)).Length);
        return powerupPool.GetPowerupFromPool(type);
    }


    public void ReturnEnemyToPool(GameObject obj)
    {
        obj.SetActive(false);
        enemiesKilled++;

        if (enemiesKilled >= 10)
        {
            //spawn the boss
            bossEnemy.SetActive(true);
            enemiesKilled = -100;
        }
    }


    public void ReturnPowerupToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

}
