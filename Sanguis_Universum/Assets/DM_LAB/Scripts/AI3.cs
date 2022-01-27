using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AI3 : MonoBehaviour
{
    public Animator animator;
    public Transform target;
    [Range(0.5f, 5f)] public float speed = 1f;
    [Range(0.5f, 50f)] public float jumpVelocity = 10f;
    [Range(0.5f, 5f)] public float jumpCooldown = 2f;
    float lastJumpTime;

    public float nextWayPointDistance = 3f;
    Path path;
    int currentWaypoint;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(UpdatePath), 0f, 0.5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            RecalculateCurrentWaypoint();
        }
    }

    void RecalculateCurrentWaypoint()
    {
        currentWaypoint = 0;
        UpdateWaypointIfFarEnough();
    }

    void FixedUpdate()
    {
        if (path == null)
            return;

        reachedEndOfPath = (currentWaypoint >= path.vectorPath.Count);
        if (reachedEndOfPath)
            return;

        UpdateWaypointIfFarEnough();

        var direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        UsePhysicsToGoThere(direction);
    }

    void UsePhysicsToGoThere(Vector2 direction)
    {
        if (direction.x > 0)
            LookRight();
        else
            LookLeft();


        var oldVelocity = rb.velocity;
        var newVelocity = oldVelocity;
        newVelocity.x = direction.x * speed;

        if (oldVelocity.y == 0 && direction.y > 0.5 && IsReadyToJump())
        {
            newVelocity.y = jumpVelocity;
            lastJumpTime = Time.realtimeSinceStartup;
        }

        rb.velocity = newVelocity;

        //Animation speed
        animator.SetFloat("Speed", Mathf.Abs(newVelocity.x));
    }

    bool IsReadyToJump()
    {
        return Time.realtimeSinceStartup - lastJumpTime > jumpCooldown;
    }

    void LookLeft()
    {
        transform.localScale = new Vector3(1, 1, 1f);
    }

    void LookRight()
    {
        transform.localScale = new Vector3(-1, 1, 1f);
    }

    bool UpdateWaypointIfFarEnough()
    {
        var waypoints = path.vectorPath.Count;
        if (currentWaypoint == waypoints - 1)
            return false;
        var distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWayPointDistance)
        {
            currentWaypoint++;
            return true;
        }

        return false;
    }
}