using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patrol : MonoBehaviour
{
    public GameObject EnenemyState;
    public GameObject[] GO;
    public float targetPosition;
    public bool localHiding;
    public float localSpeed;
    Rigidbody2D rb;

    int ObjectA;
    public AI3 localMethod;
    private void Start()
    {
        localMethod = GetComponent<AI3>();  
        rb = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        localHiding = EnenemyState.GetComponent<Hiding>().patrolState;

        if (localHiding)
        {
            if(Mathf.Round(targetPosition)  > Mathf.Round(transform.position.x))
            {
                rb.velocity = new Vector3(localSpeed, 0, 0);
            }
            else if (Mathf.Round(targetPosition) < Mathf.Round(transform.position.x))
            {
                rb.velocity = new Vector3(-localSpeed, 0, 0);
            }
            else if (Mathf.Round(targetPosition) == Mathf.Round(transform.position.x))
            {
                GetNextTarget();
            }
        }
    }

    public void GetNextTarget()
    {
        ObjectA = Random.Range(0, 4);

        switch (ObjectA)
        {
            case 0:
                targetPosition = GO[0].transform.position.x;
                break;
            case 1:
                targetPosition = GO[1].transform.position.x;
                break;
            case 2:
                targetPosition = GO[2].transform.position.x;
                break;
            case 3:
                targetPosition = GO[3].transform.position.x;
                break;
            default:
                Debug.Log("Nothing");
                break;
        }
    }
}
