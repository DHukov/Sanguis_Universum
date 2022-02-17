using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Button { Unpress, Press, }

public class Passing_Jumping_Collider : MonoBehaviour
{
    public Transform GroundCheck;
    public LayerMask m_WhatIsGround;
    float k_GroundedRadius = 0.2f;
    int Player_Layer, Box_Layer, Ground_Layer;
    bool Fall;
    public Rigidbody2D rb;
    public Collider2D feet;
    public Collider2D floorColider;
    public Collider2D boxCillider;
    float time;
    public float holdTime;
    public float startHoldTime;

    public Button buttonState;


    private void Start()
    {
        startHoldTime = holdTime;
        Player_Layer = LayerMask.NameToLayer("Player");
        Box_Layer = LayerMask.NameToLayer("Platforms");
        Ground_Layer = LayerMask.NameToLayer("Ground");

        Physics2D.IgnoreLayerCollision(Player_Layer, Box_Layer, true);
    }
    private void Update()
    {
        time = Time.deltaTime;


        if (Input.GetKeyUp(KeyCode.S))
        {
            buttonState = Button.Press;
        }
        if(buttonState == Button.Press)
        {
            holdTime -= time;
            Physics2D.IgnoreLayerCollision(Player_Layer, Box_Layer, true);

        }
        if (holdTime <= 0)
        {
            buttonState = Button.Unpress;
            holdTime = startHoldTime;
        }


        if (feet.IsTouching(floorColider))
        {
            Physics2D.IgnoreLayerCollision(Player_Layer, Box_Layer, true);
            Debug.Log("Is ground");
        }
        else if (rb.velocity.y > 0)
        {
          Physics2D.IgnoreLayerCollision(Player_Layer, Box_Layer, true);
          Debug.Log("Turn off");
        }
        else if (rb.velocity.y <= 0 && buttonState == Button.Unpress)
        {
            Physics2D.IgnoreLayerCollision(Player_Layer, Box_Layer, false);
            Debug.Log("turn On");

        }
        /*
      */


    }

    public void SomeMethod()
    {

    }

}
