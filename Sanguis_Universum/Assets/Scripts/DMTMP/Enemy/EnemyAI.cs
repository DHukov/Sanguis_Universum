using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    [Header("Pathfinding")]
    public Transform target;
    public float activateDistance = 150f;
    public float pathUpdateSeconds = 0.5f;

    [Header("Physics")]
    public float calmSpeed = 15f;
    public Transform groundDetection;
    public float distance = 5f;
    private float tmp = 10f;

    public float speed = 200f;
    public float nextWayPointDistance = 3f;
    public float jumpNodeHeightRequirenment = 0.8f;
    public float jumpModifier = 0.3f;
    public float jumpCheckOffset = 0.1f;

    [Header("Custom Behavior")]
    public bool followEnabled = true;
    public bool jumpEnabled = true;
    public bool directionLookEnabled = true;

    private Path path;
    private int currentWayPoint = 0;
    bool isGrounded = false;
    Seeker seeker;
    Rigidbody2D rb;

    public void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);
    }

    void Update()
    {
        if (followEnabled == false)
        {
            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
            if (groundInfo == false)
            {
                transform.localScale = new Vector3(gameObject.transform.localScale.x * -1, 0.5f);
                calmSpeed = calmSpeed * -1;
                if(rb.velocity.x > 0)
                {
                    tmp = -15f;
                }else
                {
                    tmp = 15f;
                }
                rb.AddForce(new Vector2 (tmp,0), ForceMode2D.Impulse);
            }
            if (rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(0.5f, 0.5f);
                calmSpeed = 15f;
            }
            else 
            {
                transform.localScale = new Vector3(-0.5f, 0.5f);
                calmSpeed = -15f;
            }
            Vector2 force = new Vector2(calmSpeed, 0);
            rb.AddForce(force);
        }
    }

    private void FixedUpdate()
    {
        if (TargetInDistance() && followEnabled)
        {
            PathFollow();
        }
    }
     
    private void UpdatePath()
    {
        if (followEnabled && TargetInDistance() && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    private void PathFollow()
    {
         if(path == null)
        {
            return;
        }

         //reach end of path
         if(currentWayPoint >= path.vectorPath.Count)
        {
            return;
        }

        //see if colliding with something
        Vector3 startOffset = transform.position - new Vector3(0f, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset);
        isGrounded = Physics2D.Raycast(startOffset, -Vector3.up, 0.01f);

        //direction calculation
        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        //jump
        if(jumpEnabled && isGrounded)
        {
            if (direction.y > jumpNodeHeightRequirenment)
            {
                rb.AddForce(Vector2.up * speed * jumpModifier);
            }
        }

        //movement
        rb.AddForce(force);

        //next waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);
        if(distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }

        //direction graphics handling
        if (directionLookEnabled)
        {
            if (rb.velocity.x > 0.05f)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }
    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.transform.position) < activateDistance;
    }
    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }
}
