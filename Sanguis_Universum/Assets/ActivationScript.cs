using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationScript : MonoBehaviour
{
    public GameObject Player;
    //public GameObject Objects;
    public float time;

    private void Start()
    {
        StartCoroutine(Active());
    }

    IEnumerator Active()
    {
        yield return new WaitForSeconds(time);
        Player.SetActive(true);
    }
}
