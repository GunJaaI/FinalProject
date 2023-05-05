using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour {
    public string tagTarget = "Player";
    public List<Collider2D> detectedObjs;
    public Collider2D collider2D;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == tagTarget) {
            detectedObjs.Add(collider);
            //this.GetComponent<EnemyAI>().enabled = true; อยากทำให้ enemyAI เซตให้เดินเมื่ออยู่ในระยะแต่ทำไม่ได้
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == tagTarget) {
            detectedObjs.Remove(collider);
            //this.GetComponent<EnemyAI>().enabled = false;
        }
    }
}
