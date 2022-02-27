using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{

    public GameObject Hero;
    public bool isActive;
    public float time = 1;
    float alpha = 1;
    public AudioSource Source;
    public AudioClip BookFallen;
    void Start()
    {
        Source = GetComponent<AudioSource>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Source.PlayOneShot(BookFallen, 1);
        time = Time.deltaTime;
        if(!isActive)
        FallingMethode();
    }
    public void FallingMethode()
    {
        alpha -= time;
        Hero.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, alpha);
        if (alpha <= 0)
        {
            Hero.GetComponent<PlayerStats>().Damage(100);
            isActive = true;
        }
    }
}
