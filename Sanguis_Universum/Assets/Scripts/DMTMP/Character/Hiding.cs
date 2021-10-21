using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
   // [SerializeField] GameObject collider;


    bool hiding;
    float speedTmp;
    float jumpTmp;
    public void Hide()
    {
        if (hiding == false)
        {
            hiding = true;
            speedTmp = player.GetComponent<CharController>().runSpeed;
            jumpTmp = player.GetComponent<CharController>().m_JumpForce;

            player.GetComponent<CharController>().runSpeed = 0f;
            player.GetComponent<CharController>().m_JumpForce = 0f;

            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.GetComponent<BoxCollider2D>().isTrigger = true;
            player.GetComponent<CapsuleCollider2D>().isTrigger = true;
            player.GetComponent<SpriteRenderer>().enabled = false;

            enemy.GetComponent<EnemyAI>().followEnabled = false;
            //enemy.GetComponent<Rigidbody2D>().gravityScale = 0;
            //collider.GetComponent<BoxCollider2D>().enabled = false;

        }
        else
        {
            hiding = false;
            player.GetComponent<CharController>().runSpeed = speedTmp;
            player.GetComponent<CharController>().m_JumpForce = jumpTmp;

            player.GetComponent<Rigidbody2D>().gravityScale = 2;
            player.GetComponent<BoxCollider2D>().isTrigger = false;
            player.GetComponent<CapsuleCollider2D>().isTrigger = false;
            player.GetComponent<SpriteRenderer>().enabled = true;

            enemy.GetComponent<EnemyAI>().followEnabled = true;
            //enemy.GetComponent<Rigidbody2D>().gravityScale = 2;
        }
    }
}
