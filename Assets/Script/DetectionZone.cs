using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour {
    public string target = "Player";
    public List<Collider2D> detectedObjs;
    public Collider2D collider2D;
    
    EnemyAI enemyAIIsEnable;

    private void Start() {
        enemyAIIsEnable = GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == target) {
            detectedObjs.Add(collider);
            // enemyAIIsEnable.EnemyScriptEnabledTrue(); //อยากทำให้ enemyAI เซตให้เดินเมื่ออยู่ในระยะแต่ทำไม่ได้
        } else {
            // enemyAIIsEnable.EnemyScriptEnabledFalse();
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == target) {
            detectedObjs.Remove(collider);
            // enemyAIIsEnable.EnemyScriptEnabledFalse();
        }
    }
}
