using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour
{
    
    void Start()
    {
        transform.position = new Vector3(5, -3.53f, -4.58f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Input.mousePosition.x * 0.001f, Input.mousePosition.y * 0.001f, -13);
    }
}
