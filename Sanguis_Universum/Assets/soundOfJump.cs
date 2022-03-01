using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundOfJump : MonoBehaviour
{
    public AudioSource source;
    public AudioClip jump;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !source.isPlaying)
        {
            source.clip = jump;
            source.pitch = 1f;
            source.volume = 1f;
            source.Play();
        }
    }
}
