using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] private int health = 100;
    public int MAX_HEALTH = 100;
    public HealthBar healthBar;

    void Start() {
        health = MAX_HEALTH;
        healthBar.SetMaxHealth(MAX_HEALTH);
    }

    //Update is called once per frame
    void Update() {
        // if (Input.GetKeyDown(KeyCode.Space)) { //test method
        //     Damage(10);
        //     Debug.Log("damage?");
        // }

        // if (Input.GetKeyDown(KeyCode.H)) { //test method
        //     // Heal(10);
        // }
    }

    public void Damage(int amount) {
        if (amount < 0) {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damade!");
        }
        health -= amount;
        healthBar.SetHealth(health);

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
            healthBar.SetHealth(MAX_HEALTH);
        } else {
            this.health += amount; // when heal not full
            healthBar.SetHealth(health);
        }
        this.health += amount;
        healthBar.SetHealth(health);    
    }

    private void Die() {
        Debug.Log("Did Im Dead!?");
        healthBar.SetHealth(health);
        Destroy(gameObject);
    }
}
