using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] float attackDuration;
    [SerializeField] float attackInterval;

    Vector3 attack_MaxScale;


    void Start()
    {
        attack_MaxScale = transform.localScale;
        InvokeRepeating(nameof(DoAttack), 1f, attackInterval);    
    }


    void DoAttack()
    {
        //animate the attack region 
        StartCoroutine(PlayAttackAnim());
    }


    IEnumerator PlayAttackAnim()
    {
        //set attack region scale to 0 before starting anim
        transform.localScale = Vector3.zero;

        //the anim lerps the scale from 0 to max
        float elapsedTime = 0f;

        while (elapsedTime < attackDuration)
        {
            elapsedTime += Time.deltaTime;

            transform.localScale = Vector3.Lerp(Vector3.zero, attack_MaxScale, elapsedTime / attackDuration);

            yield return null;
        }

        //set attack region scale to 0 after anim ends
        transform.localScale = Vector3.zero;

    }


}
