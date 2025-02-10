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


    /*[SerializeField] */Transform target;
    [SerializeField] Slider hpBar;


    void OnEnable()
    {
        Hp = maxHp;
        hpBar.maxValue = maxHp;
        hpBar.value = maxHp;

        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        MoveTowardsPlayer();    
    }


    void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            TakeDamage(1);
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



    



}
