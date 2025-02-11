using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    Player playerScript;


    void Start()
    {
        playerScript = GetComponentInParent<Player>();    
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpeedUp"))
        {
            playerScript.SpeedUp(1);
            Pool.Instance.ReturnPowerupToPool(collision.gameObject);
        }   
        
        if (collision.CompareTag("Heal"))
        {
            playerScript.Heal(2);
            Pool.Instance.ReturnPowerupToPool(collision.gameObject);  
        }
    }
}
