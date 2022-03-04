using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterSound : MonoBehaviour
{
    AudioSource source;
    public AudioClip[] clip;

    int rand;
    public int prcnt;

    // Update is called once per frame
    private void Start()
    {
        source = this.GetComponent<AudioSource>();
    }
    void Update()
    {
        rand = Random.Range(0, 99);
        if (rand <= prcnt)
        {
            if (!source.isPlaying)
            {
                source.clip = clip[Random.Range(0,2)];
                source.Play();
            }
        }
    }
}
