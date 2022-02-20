using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtManager : MonoBehaviour
{
    public Rigidbody2D player;

    public GameObject oblako;

    void OnTriggerEnter2D(Collider2D player)
    {
        oblako.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D player)
    {
        StartCoroutine(WaitBeforeDestroy());
    }
    IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);

    }
}
