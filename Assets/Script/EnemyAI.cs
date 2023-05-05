using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour {
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public Transform enemyGFX;
    public Collider2D attackRange;

    Path path;
    private int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    private Animator anim;

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start() {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
        
    }

    void UpdatePath() {
        if (seeker.IsDone()) {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p) {
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }

    public bool enemyTurnLeft;

    // Update is called once per frame
    void FixedUpdate() {
        Walking();
        if (path == null) {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count) {
            reachedEndOfPath = true;
            //Walking();
            return;
        } else {
            reachedEndOfPath = false;
            StopWalking();
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance) {
            currentWaypoint++;
        }

        //enemyGFX Flip
        // if (rb.velocity.x >= 0.01f) {
        //     enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        // } else if (rb.velocity.x <= 0.01f) {
        //     enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        // }
        if (force.x >= 0.01f) {
            if (enemyTurnLeft) {
                EnemyTurnLeft();
            } else {
                EnemyTurnRight();
            }

            //enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        } else if (force.x <= 0.01f) {
            if (enemyTurnLeft == !enemyTurnLeft) {
                EnemyTurnRight();
            } else {
                EnemyTurnLeft();
            }

            //enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }

        // // Flip the attack range along with the enemy graphic
        // if (enemyTurnLeft) {
        //     //attackRange.transform.localPosition = new Vector3(-0.5f, 0f, 0f);
        //     attackRange.transform.localScale = new Vector3(-1f, 1f, 1f);
        // } else {
        //     //ttackRange.transform.localPosition = new Vector3(0.5f, 0f, 0f);
        //     attackRange.transform.localScale = new Vector3(1f, 1f, 1f);
        // }
    }

    void Walking() {
        anim.SetBool("Walk", true);
    }

    void StopWalking() {
        anim.SetBool("Walk", false);
    }

    public void EnemyTurnLeft() {
        enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        attackRange.transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    public void EnemyTurnRight() {
        enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        attackRange.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
