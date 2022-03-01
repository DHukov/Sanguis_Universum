using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Damage : MonoBehaviour
{
    public GameObject Player;
    public Animator animator;

    public float DistanceBetween_PlayerAndEnemy;
    public float Atack_Distance;

    private float Distance;
    public void Update()
    {
        Distance = Vector3.Distance(gameObject.transform.position, Player.transform.position);
        //Debug.Log(Distance + "metres");

        if (Distance <= Atack_Distance && Player.GetComponent<Hiding>().hiding == false)
        {
            animator.SetTrigger("Atack");
            Debug.Log(Distance);
        }

        if (Distance <= DistanceBetween_PlayerAndEnemy && Player.GetComponent<Hiding>().hiding == false)
        {
            Player.GetComponent<PlayerStats>().Damage(101);
        }
    }
}
