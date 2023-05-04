using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
    #region Public Variables
    public Transform raycast;
    public LayerMask raycastMask;
    public float raycastLength;
    public float attackDistance; //Minimium distance for attack
    public float moveSpeed;
    public float timer; //Timer for cooldown between attacks
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance; //Store the distance between enemy & player
    private bool attackMode;
    private bool inRange; //Check if player is in range
    private bool cooling; //Check if enemy is cooling after attack
    private float intTimer;
    #endregion

    void Awake() {
        intTimer = timer; //Store the inital value of timer
        anim = GetComponent<Animator>();
    }

    void Update() {
        if (inRange == true) {
            hit = Physics2D.Raycast(raycast.position, Vector2.left, raycastLength, raycastMask);
            RaycastDebugger();
        }
        //When Player is detected
        if (hit.collider != null) {
            EnemyLogic();
        } else if (hit.collider == null) {
            inRange = false;
        }

        if (inRange == false) {
            anim.SetBool("Walk", false);
            StopAttack();  
        }
    }

    void OnTriggerEnter2D(Collider2D trig) {
        if (trig.gameObject.tag == "Player") {
            target = trig.gameObject;
            inRange = true;
        }
    }

    void EnemyLogic() {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance > attackDistance) {
            Move();
            StopAttack(); 
        } else if (attackDistance >= distance && cooling == false) {
            Attack();
        }

        if (cooling == true) {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void RaycastDebugger() {
        if (distance > attackDistance) {
            Debug.DrawRay(raycast.position, Vector2.left * raycastLength, Color.red);
        } else if (attackDistance > distance) {
            Debug.DrawRay(raycast.position, Vector2.left * raycastLength, Color.green);
        }
    }

    void Move() {
        anim.SetBool("Walk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("EnemyAttackLeftAnimation")) {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack() {
        timer = intTimer; //Reset Timer when Player enter attack range
        attackMode = true; //To check if enemy can still attack or not

        anim.SetBool("Walk", false);
        anim.SetBool("Attack", true);
        Debug.Log("Enemy Attack!");
    }

    void Cooldown() {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode) {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack() {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }

    void TriggerCooling() {
        cooling = true;
    }
}
