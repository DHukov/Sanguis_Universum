using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    //[SerializeField] GameObject enemy;


    // [SerializeField] GameObject collider;

    public bool hiding;
    float speedTmp;
    float jumpTmp;
    float seekerDistance;
    public float overviewRange;
    public bool patrolState;


    public void Hide()
    {
        seekerDistance = Vector3.Distance(enemy.transform.position, player.transform.position);
        if (hiding == false)
        {
            hiding = true;
            if (seekerDistance > overviewRange)
            {
                    Patrol();   

            }
            else if (player.transform.position.y > 25)
            {
                Patrol();

            }
            else if (seekerDistance < overviewRange)
            {
                NoPatrol();

            }

            speedTmp = player.GetComponent<CharController>().runSpeed;
            player.GetComponent<CharController>().runSpeed = 0f;

            jumpTmp = player.GetComponent<CharController>().m_JumpForce;
            player.GetComponent<CharController>().m_JumpForce = 0f;

            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            //player.GetComponent<BoxCollider2D>().isTrigger = true;
            player.GetComponent<CapsuleCollider2D>().isTrigger = true;
            player.GetComponent<SpriteRenderer>().enabled = false;

            enemy.GetComponent<AI3>().followEnabled = false;
            //enemy.GetComponent<Rigidbody2D>().gravityScale = 0;
            //collider.GetComponent<BoxCollider2D>().enabled = false;

        }
        else
        {
            NotHiding();
            //enemy.GetComponent<Rigidbody2D>().gravityScale = 2;
        }
    }

    public void NoPatrol()
    {
        patrolState = false;
        enemy.GetComponent<AI3>().enabled = true;
    }

    public void Patrol()
    {
        patrolState = true;
        enemy.GetComponent<AI3>().enabled = false;
        enemy.GetComponent<Enemy_Patrol>().GetNextTarget();
    }

    public void NotHiding()
    {
        enemy.GetComponent<AI3>().enabled = true;
        patrolState = false;


        hiding = false;
        player.GetComponent<CharController>().runSpeed = speedTmp;
        player.GetComponent<CharController>().m_JumpForce = jumpTmp;

        player.GetComponent<Rigidbody2D>().gravityScale = 1;
        //player.GetComponent<BoxCollider2D>().isTrigger = false;
        player.GetComponent<CapsuleCollider2D>().isTrigger = false;
        player.GetComponent<SpriteRenderer>().enabled = true;

        enemy.GetComponent<AI3>().followEnabled = true;
    }
}
