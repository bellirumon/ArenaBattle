using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{

    void Awake()
    {
        GlobalData.SetArenaBounds(GetComponent<SpriteRenderer>().bounds);    
    }

}
