using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + (player.position.y * (-0.1f)), transform.position.z);

        //if (player.position.y >= -5)
        //{
        //    transform.position = new Vector3(player.position.x, player.position.y - 0.8f, transform.position.z);
        //}
        //else
        //{
        //    transform.position = new Vector3(player.position.x, player.position.y + player.position.y + 13f, transform.position.z);
        //}
    }
}
