using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeed;
    [SerializeField] private int damage;
    float timeUntilMelee;
    public bool a = true;

    // Update is called once per frame
    public void Update() {
        if (timeUntilMelee <= 0f) {
            a = true;

            // if (Input.GetMouseButtonDown(0)) {
            //     anim.SetTrigger("Attack");
            //     timeUntilMelee = meleeSpeed;
            // }
        } else {
            timeUntilMelee -= Time.deltaTime;
            a = false;
        }
    }

    public void OnClick() {
        if (a == true) {
            anim.SetTrigger("Attack");
            timeUntilMelee = meleeSpeed;
            Debug.Log("Attack!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
       if (other.tag == "Enemy") {
            other.GetComponent<Health>().Damage(damage);
            //Debug.Log("Enemy hit");
        } 
    }
}
