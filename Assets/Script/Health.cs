using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] private int health = 100; //main health
    public int MAX_HEALTH = 100; // Max health
    public HealthBar healthBar; // HealthBar Componenet

    public GameObject healthText; // HealthText in canvas
    public int enemyAmount = 0;
    private Animator anim;

    void Start() {
        health = MAX_HEALTH;
        healthBar.SetMaxHealth(MAX_HEALTH);
        anim = GetComponent<Animator>();
    }

    //Update is called once per frame
    void FixedUpdate() {
        // if (Input.GetKeyDown(KeyCode.Space)) { //test method
        //     Damage(10);
        //     Debug.Log("damage?");
        // }

        // if (Input.GetKeyDown(KeyCode.H)) { //test method
        //     Heal(10);
        // }
    }

    public void Damage(int amount) {
        if (amount < 0) {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damade!");
        }
        anim.SetTrigger("Hurt");

        health -= amount;
        healthBar.SetHealth(health);

        RectTransform textTransform = Instantiate(healthText).GetComponent<RectTransform>();
        textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        textTransform.SetParent(canvas.transform);

        if (health <= 0) {
            anim.SetTrigger("Die");
            //Die();
        }
    }

    public void Heal(int amount) {
        if (amount < 0) {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Healing!");
        }
        anim.SetTrigger("Heal");

        bool overMaxHealth = (health + amount > MAX_HEALTH);

        RectTransform textTransform = Instantiate(healthText).GetComponent<RectTransform>();
        textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        textTransform.SetParent(canvas.transform);

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
