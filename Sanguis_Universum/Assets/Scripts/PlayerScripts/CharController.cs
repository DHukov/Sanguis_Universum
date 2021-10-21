using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.Rendering.PostProcessing;

public class CharController : MonoBehaviour
{

    public Animator animator;

    public Transform GroundCheck;
    public LayerMask m_WhatIsGround;
    public Transform CeilingCheck;
    public Collider2D CrouchDisableCollider;
    private PlatformEffector2D effector;

    public float m_JumpForce = 400f;
    const float k_GroundedRadius = .05f;
    const float k_CeilingRadius = .2f;
    private bool m_Grounded;
    private bool m_FacingRight = true;
    private Vector3 m_Velocity = Vector3.zero;
    private Rigidbody2D m_Rigidbody2D;
    private float m_MovementSmooth = .05f;
    public float waitTime;

    bool jump = false;
    bool crouch;
    float h_Move = 0f;
    public float runSpeed = 40f;
    public float crouchSpeed = 5f;

    public UnityEvent OnLandEvent;
    public VectorValue PlayerPosition;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    private void Start()
    {

        //PlayerPosition.initialValue = transform.position;
        // transform.localScale = PlayerPosition.scaleValue;

    }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;


    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        effector = GetComponent<PlatformEffector2D>();

        if (OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }

        if (OnCrouchEvent == null)
        {
            OnCrouchEvent = new BoolEvent();
        }
    }


    /*void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }*/


    public void Move(float move, bool crouch, bool jump)
    {

        if (!crouch)
        {
            if (Physics2D.OverlapCircle(CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
            }
        }

        if (m_Grounded || !m_Grounded)
        {

            if (crouch)
            {
                if (!m_wasCrouching)
                {
                    m_wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }

                
                move *= crouchSpeed * 0.1f;

                
                if (CrouchDisableCollider != null)
                    CrouchDisableCollider.enabled = false;
            }
            else
            {
                
                if (CrouchDisableCollider != null)
                    CrouchDisableCollider.enabled = true;

                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }

            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);

            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmooth);

            if (move > 0 && !m_FacingRight)
            {

                Flip();
            }

            else if (move < 0 && m_FacingRight)
            {

                Flip();
            }
        }

        if (m_Grounded && jump)
        {

            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce * 100));

        }
    }

    void Flip()
    {

        m_FacingRight = !m_FacingRight;
        //PlayerPosition.scaleValue.x *= -1;
        Vector3 theScale = transform.localScale;

        theScale.x *= -1;
        transform.localScale = theScale;
    }


    void Update()
    {
        h_Move = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(h_Move));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetTrigger("JumpStart");

        }

        if (Mathf.Abs(h_Move) > 0 || !m_Grounded)
        {

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            crouch = true;

        } else if (Input.GetKeyUp(KeyCode.S))
        {
            crouch = false;
        }

        if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.Space))
        {
            if (waitTime <=0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 1f;
            }
            else
            {
                effector.rotationalOffset = 0f;
            }
        }

    }

    public void OnLanding ()
    {

        animator.SetTrigger("Landing");
    }

    public void OnCrouching (bool isCrouching)
    {
        animator.SetBool("Crouch", isCrouching);
    }


    void FixedUpdate()
    {
        animator.ResetTrigger("Landing");
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        //Collider[] colliders = Physics.OverlapSphere(GroundCheck.position, k_GroundedRadius);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                OnLanding();
                //Debug.Log(colliders[i].name);
            }
        }

        Move(h_Move * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }
}