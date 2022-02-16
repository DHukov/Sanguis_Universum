using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer_Script : MonoBehaviour
{
    public GameObject Player;
    public GameObject TriggeredItems;

    public bool isActive = true;



    void OnTriggerEnter2D()
    {
        if(isActive)
        ScareMe();
    }

    public void ScareMe()
    {
        Debug.Log("GameObject1 collided with " + Player);
        isActive = false;
    }
}
