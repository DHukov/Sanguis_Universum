using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Rendering.PostProcessing;

public class PlayerController : MonoBehaviour
{
   // [SerializeField] PostProcessVolume postProcess;
    [SerializeField] SpriteRenderer swordFire;
    private Rigidbody2D _rigidbody;
    private CapsuleCollider2D _collider;
   // private Animator _animator;
    public LayerMask layermask;

    public float speed = 4f;
    public float jump = 8f;
    bool swordInFire = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();
     //   _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        
        if (Input.GetKeyDown(KeyCode.C))
        {
            //     _animator.Play("Attack");
            Debug.Log("dsa");
            
        }

        if (direction < 0.0f)
        {
            _rigidbody.velocity = new Vector2(-speed, _rigidbody.velocity.y);
            transform.localScale = new Vector3(-0.3f , 0.3f);
        //    _animator.SetBool("walking" , true);
        }
        else if(direction > 0.0f)
        {
            _rigidbody.velocity = new Vector2(speed, _rigidbody.velocity.y);
            transform.localScale = new Vector3(0.3f, 0.3f);
         //   _animator.SetBool("walking", true);
        }
        else
        {
         //   _animator.SetBool("walking", false);
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _collider.IsTouchingLayers(layermask))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jump);
        //    _animator.Play("Jump");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(!swordInFire)
            {

                swordInFire = true;
                //postProcess.weight = 0.5f;
                swordFire.enabled = true;
            }
            else
            {
                swordInFire = false;
                //postProcess.weight = 1f;
                swordFire.enabled = false;
            }

        }

    }

    

}
