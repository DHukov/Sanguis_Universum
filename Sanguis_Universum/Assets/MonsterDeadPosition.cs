using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDeadPosition : MonoBehaviour
{
    public GameObject monster_pos;
    void Update()
    {
        
        this.transform.position = new Vector3(monster_pos.transform.position.x, 
            this.transform.position.y, this.transform.position.z);
    }
}
