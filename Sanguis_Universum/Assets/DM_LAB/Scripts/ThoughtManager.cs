using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtManager : MonoBehaviour
{
    public Rigidbody2D player;
    public GameObject oblako;

    public float _time;
    void OnTriggerEnter2D(Collider2D player)
    {
        oblako.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D player)
    {
        StartCoroutine(WaitBeforeDestroy());

        if(gameObject.transform.GetChild(1) != null)
        {
            Destroy(gameObject.transform.GetChild(1).gameObject);
        }

    }
    IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSeconds(_time);
        Destroy(gameObject);
    }
}
