using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Screamer_Script : MonoBehaviour
{
    public GameObject Player;
    public GameObject GO;
    public BoxCollider2D floor;
    public AudioSource Source;
    public AudioClip BookFallen;
    public AudioClip ScareSound;
    public bool onFloor;

    public bool isActive;
    void Start()
    {
        Source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        
        if (GO.GetComponent<BoxCollider2D>().IsTouching(floor) && onFloor)
        {
            onFloor = false;
            Source.PlayOneShot(BookFallen, 1f);
           
            Debug.Log("work");
            //sound
        }

    }

    void OnTriggerEnter2D()
    {
        //StartCoroutine(ColliderOn());
        if(isActive)
        ScareMe();


    }

    public void ScareMe()
    {
        
        GO.SetActive(true);
        Debug.Log("GameObject1 collided with " + Player);
        //GO.GetComponent<BoxCollider2D>().enabled = false;
        Source.PlayOneShot(ScareSound, 1f);
        isActive = false;
    }

    IEnumerator ColliderOn()
    {
        yield return new WaitForSeconds(0.5f);
        GO.GetComponent<BoxCollider2D>().enabled = true;

    }
}
