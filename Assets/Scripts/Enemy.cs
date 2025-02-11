using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHp;
    [SerializeField] int hp;
    public int Hp { get => hp; private set => hp = value; }

    [SerializeField] int moveSpeed;
    public int MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }


    [SerializeField] Transform targetBody;
    [SerializeField] Player targetPlayerScript;
    [SerializeField] Slider hpBar;
    [SerializeField] float attackInterval;


    void OnEnable()
    {
        Hp = maxHp;
        hpBar.maxValue = maxHp;
        hpBar.value = maxHp;

        targetBody = GameObject.FindGameObjectWithTag("PlayerBody").transform;
        targetPlayerScript = targetBody.GetComponentInParent<Player>();
    }


    void Update()
    {
        MoveTowardsPlayer();    
    }


    void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetBody.position, moveSpeed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            TakeDamage(1);
        }
        
        if (collision.CompareTag("PlayerBody"))
        {
            InvokeRepeating(nameof(TickDamage), 0f, attackInterval);
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBody"))
        {
            CancelInvoke(nameof(TickDamage));
        }    
    }


    void TakeDamage(int dmg)
    {
        Hp -= dmg;

        hpBar.value = Hp;

        if (Hp <= 0)
        {
            Pool.Instance.ReturnToPool(gameObject);
        }

    }

    
    void TickDamage()
    {
        targetPlayerScript.TakeDamage(1);
    }

}
