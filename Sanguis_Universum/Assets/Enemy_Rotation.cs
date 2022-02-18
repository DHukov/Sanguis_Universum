using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Rotation : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if (m_Rigidbody.velocity.x > 0.1)
            LookRight();
        else if (m_Rigidbody.velocity.x < -0.1)
            LookLeft();
    }
    public void LookLeft() => transform.localScale = new Vector3(1, 1, 1f);
    public void LookRight() => transform.localScale = new Vector3(-1, 1, 1f);
}
