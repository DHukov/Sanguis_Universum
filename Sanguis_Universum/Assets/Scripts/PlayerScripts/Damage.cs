using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Damage : MonoBehaviour
{
    public UnityEvent damage;
    public GameObject Player;
    public Animator animator;

    public float DistanceBetween_PlayerAndEnemy;
    public float Atack_Distance;

    private float Distance;
    public void Update()
    {
        Distance = Vector3.Distance(gameObject.transform.position, Player.transform.position);
        //Debug.Log(Distance + "metres");

        if (Atack_Distance <= Distance)
        {
            animator.SetTrigger("Atack");
            Debug.Log("Anim");
        }

        if (Distance <= DistanceBetween_PlayerAndEnemy)
        {
            damage.Invoke();
            Debug.Log(damage);
        }
    }
}
