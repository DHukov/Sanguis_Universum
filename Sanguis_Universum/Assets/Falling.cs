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
    private void Update()
    {
        if (isActive)
            FallingMethode();
        time = Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isActive = true;
        Source.PlayOneShot(BookFallen, 1);
        
    }
    public void FallingMethode()
    {
        alpha -= time;
        Hero.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, alpha);
        if (alpha <= 0)
        {
            Hero.GetComponent<PlayerStats>().Damage(101);
            isActive = false;
        }
    }
}
