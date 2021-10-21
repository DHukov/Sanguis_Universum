using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpened;

    public void IsUsed(GameObject obj)
    {
        if (!isOpened){
            PlayerManager manager = obj.GetComponent<PlayerManager>();
            if (manager.key1)
            {
                isOpened = true;
                manager.useKey1();
            }
        }
    }
}
