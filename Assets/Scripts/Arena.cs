using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    
    public Bounds GetArenaBounds()
    {
        return GetComponent<SpriteRenderer>().bounds;
    }


}
