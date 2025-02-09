using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSpawnRegion : MonoBehaviour
{
    SpriteRenderer noSpawnRegion;


    void Awake()
    {
        noSpawnRegion = GetComponent<SpriteRenderer>();    
    }


    void Update()
    {
        //compute the allowed spawn region which is equal to total arena area - nospawnregion
        GlobalData.SetNoSpawnRegion(noSpawnRegion.bounds);
    }


}
