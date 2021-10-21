using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public bool isOpen;
    public Animator animator;

    public void OpenChest()
    {
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("Chest hes been opened");
            animator.SetBool("Opened", isOpen);
        }
    }
}
