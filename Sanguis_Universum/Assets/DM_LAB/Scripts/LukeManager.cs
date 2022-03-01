using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LukeManager : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            body.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
