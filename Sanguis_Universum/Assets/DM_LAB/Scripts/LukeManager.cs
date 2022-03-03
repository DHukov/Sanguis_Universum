using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LukeManager : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    [SerializeField] Rigidbody2D body1;

    public void UnlockLucke()
    {
            body.bodyType = RigidbodyType2D.Dynamic;
            body1.bodyType = RigidbodyType2D.Dynamic;
    }

}
