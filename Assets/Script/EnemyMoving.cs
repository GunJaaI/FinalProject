using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour {

    [Header("Enemy")] 
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")] 
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;
    private Animator anim;
    private EnemyAI enemyAI;


    // Start is called before the first frame update
    void Awake() {
        initScale = enemy.localScale;
        anim = GetComponent<Animator>();
        enemyAI = GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update() {
        if (movingLeft) {
            if (enemyAI.enemyTurnLeft == true/*enemy.position.x >= enemyAI.currentWaypoint*/) {
                MoveInDirection(-1);
            } else {
                //Change direction
                DirectionChange();
            }
        } else {
            if (enemyAI.enemyTurnLeft == false/*enemy.position.x <= enemyAI.currentWaypoint*/) {
                MoveInDirection(1);
            } else {
                //Change direction
                DirectionChange();
            }
        }
    }

    private void DirectionChange() {
        movingLeft = !movingLeft;
    }

    private void MoveInDirection(int direction) {
        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);
        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed, 
        enemy.position.y, enemy.position.z);
        
    }
}
