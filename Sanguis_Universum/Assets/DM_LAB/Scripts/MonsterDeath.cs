using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDeath : MonoBehaviour
{
    [SerializeField] GameObject monster;
    public GameObject DeadPrefab;
    public GameObject teleport;
    void Update()
    {
        DeadPrefab.transform.position = new Vector3(monster.transform.position.x,
        DeadPrefab.transform.position.y, DeadPrefab.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("OPA NIHUYA");
            Destroy(monster);
            DeadPrefab.SetActive(true);
            StartCoroutine(StartEpologue());
        }
    }
    IEnumerator StartEpologue()
    {
        yield return new WaitForSeconds(4);
        teleport.GetComponent<SwitcherOfScenes>().Teleport();
    }
}
