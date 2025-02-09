using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    #region Static Singleton 

    public static SpawnManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Another instance of SpawnManager exists! Destroying this Instance");
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    #endregion

    [SerializeField] GameObject enemyPrefab;

    [SerializeField] float delayBeforeStartSpawn;
    [SerializeField] float spawnInterval;

    Bounds arenaBounds;


    void Start()
    {
        arenaBounds = GlobalData.ArenaBounds;

        InvokeRepeating(nameof(SpawnEnemy), delayBeforeStartSpawn, spawnInterval);
    }


    void SpawnEnemy()
    {
        //get a random spawn point within the arena
        float spawnXPos = Random.Range(arenaBounds.min.x + 0.5f, arenaBounds.max.x - 0.5f); //0.5 is buffer so that half enemy body isnt outside the arena when it spawns
        float spawnYPos = Random.Range(arenaBounds.min.y + 0.5f, arenaBounds.max.y - 0.5f); //0.5 is buffer so that half enemy body isnt outside the arena when it spawns

        Vector3 spawnPos = new(spawnXPos, spawnYPos, 0f);

        //check if this spawn point is within the No Spawn Region or not
        if (GlobalData.NoSpawnRegion.Contains(spawnPos))
        {
            SpawnEnemy();
            return;
        }

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

    }


}
