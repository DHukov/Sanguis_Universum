using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    [SerializeField] AudioSource Audio_Src;

    public AudioClip SoundClip;

    public bool isInRange;
    public bool AccesToKey = true;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    void Update()
    {
        HideButton();
    }

    private void HideButton()
    {
        if (isInRange && AccesToKey)
        {
            if (Input.GetKeyDown(interactKey))
            {
                Audio_Src.PlayOneShot(SoundClip);
                AccesToKey = false;
                interactAction.Invoke();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("I'm near something!");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Anyway...");
        }
    }
}
