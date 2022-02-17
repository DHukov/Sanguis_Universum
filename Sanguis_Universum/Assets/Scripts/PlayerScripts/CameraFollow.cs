using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float dampT = 0.15f;
    private Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        Vector3 endpoint = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, endpoint, ref velocity, dampT);
        
    }
}
