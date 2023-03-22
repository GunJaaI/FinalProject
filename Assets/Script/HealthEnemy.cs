using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private int healthEnemy = 100;
    public int MAX_HEALTH_ENEMY = 100;
    public HealthBar healthBar;

    void Start() {
        healthEnemy = MAX_HEALTH_ENEMY;
        healthBar.SetMaxHealth(MAX_HEALTH_ENEMY);
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
        healthEnemy -= amount;
        healthBar.SetHealth(healthEnemy);

        if (healthEnemy <= 0) {
            Die();
        }
    }

    public void Heal(int amount) {
        if (amount < 0) {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Healing!");
        }

        bool overMaxHealth = (healthEnemy + amount > MAX_HEALTH_ENEMY) ;

        if (overMaxHealth) {
            this.healthEnemy = MAX_HEALTH_ENEMY; // when over heal
            healthBar.SetHealth(MAX_HEALTH_ENEMY);
        } else {
            this.healthEnemy += amount; // when heal not full
            healthBar.SetHealth(healthEnemy);
        }
        this.healthEnemy += amount;
        healthBar.SetHealth(healthEnemy);    
    }

    private void Die() {
        Debug.Log("Enemy Dead!?");
        healthBar.SetHealth(healthEnemy);
        Destroy(gameObject);
    }
}
