using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class CutScenes : MonoBehaviour
{
    public GameObject timeLine;
    public GameObject destroy;
    public GameObject enemy;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        timeLine.SetActive(true);
        timeLine.GetComponent<PlayableDirector>().Play();
        StartCoroutine(DestoyObject());
    }
    IEnumerator DestoyObject()
    {
        yield return new WaitForSeconds(5);
        enemy.SetActive(true);
        destroy.SetActive(false);
    }
}
