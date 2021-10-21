using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Animator animator;
    public Transform AttackProbe;
    public LayerMask enemyLayers;

    public float attackDistance = 0.5f;
    public int attackStr = 30;

    public float attackSpeed = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackSpeed;
            }
        }
        
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] enemyDamage = Physics2D.OverlapCircleAll(AttackProbe.position, attackDistance, enemyLayers);

        foreach (Collider2D enemy in enemyDamage)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackStr);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (AttackProbe == null)
            return;


        Gizmos.DrawWireSphere(AttackProbe.position, attackDistance);
    }

}
