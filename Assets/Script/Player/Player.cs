using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public MovementJoystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    private Animator anim;
    //private Vector2 playerDirection;
    
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        /* //PC Scripts
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(directionX,directionY).normalized;
        */
    }

    void FixedUpdate() {
        if (movementJoystick.joystickVec.y != 0) {
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed,movementJoystick.joystickVec.y * playerSpeed);
            anim.SetBool("Walk", true);
            if (movementJoystick.joystickVec.x <= 0) {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            } else if (movementJoystick.joystickVec.x >= 0) {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        } else {
            rb.velocity = Vector2.zero;
            anim.SetBool("Walk", false);
        }
        /* //PC Scripts
        rb.velocity = new Vector2(playerDirection.x * playerSpeed,playerDirection.y * playerSpeed); 
        */
    }
}
