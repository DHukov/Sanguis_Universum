using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccesToKey : MonoBehaviour
{
    public GameObject player_key;
    public void OpenLuke()
    {
        if (player_key.GetComponent<PlayerStats>().key1)
        {
            this.GetComponent<LukeManager>().UnlockLucke();
        }
    }
}

