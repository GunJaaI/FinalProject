using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] private int health = 100;
    private int MAX_HEALTH = 100;

    // Update is called once per frame
    // void Update() {
    //     if (Input.GetKeyDown(KeyCode.D)) { //test method
    //         //Damage(10); 
    //     }

    //     if (Input.GetKeyDown(KeyCode.H)) { //test method
    //         // Heal(10);
    //     }
    // }

    public void Damage(int amount) {
        if (amount < 0) {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damade!");
        }
        health -= amount;

        if (health <= 0) {
            Die();
        }
    }

    public void Heal(int amount) {
        if (amount < 0) {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Healing!");
        }

        bool overMaxHealth = (health + amount > MAX_HEALTH) ;

        if (overMaxHealth) {
            this.health = MAX_HEALTH; // when over heal
        } else {
            this.health += amount; // when heal not full
        }
        this.health += amount;
    }

    private void Die() {
        Debug.Log("Did Im Dead!?");
        Destroy(gameObject);
    }
}
