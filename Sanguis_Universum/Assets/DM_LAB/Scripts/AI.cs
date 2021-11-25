using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Transform groundDetection;
    [SerializeField] float distance;
    [SerializeField] bool agressive = false;
    [SerializeField] float speed;
    private void Update()
    {
        if (agressive == false)
        {
            Calm();
        }
    }

    private void Calm()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            speed *= -1;
            transform.localScale = new Vector3(gameObject.transform.localScale.x * -1, 1f, 1f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (target.transform.position.x > transform.position.x)
            {
                RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
                if (groundInfo.collider == true)
                    transform.position += new Vector3(3f * Time.deltaTime, 0, 0);
            }
            else if(target.transform.position.x < transform.position.x)
            {
                RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
                if (groundInfo.collider == true)
                    transform.position += new Vector3(-3f * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.position += new Vector3(0 * Time.deltaTime, 0, 0);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            agressive = true;
            Debug.Log("Spotted him");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            agressive = false;
            Debug.Log("Lost him");
        }
    }
}
