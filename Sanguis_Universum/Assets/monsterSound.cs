using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    int rand;

    // Update is called once per frame
    void Update()
    {
        rand = Random.Range(0, 2);
        if (rand == 1 || rand == 0)
        {
            if (!source.isPlaying)
            {
                source.clip = clip;
                source.Play();
            }
        }
    }
}
