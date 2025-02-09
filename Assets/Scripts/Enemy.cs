using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int hp;
    public int Hp { get => hp; private set => hp = value; }

    [SerializeField] int moveSpeed;
    public int MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }


    [SerializeField] Transform target;


    void Update()
    {
        MoveTowardsPlayer();    
    }


    void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }




}
