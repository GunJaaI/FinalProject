using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemyCollider : MonoBehaviour
{
    private Vector3 localScale;
    private Transform parentTransform;

    private void Start() {
        localScale = transform.localScale;
        parentTransform = transform.parent;
    }

    private void Update() {
        if (parentTransform.localScale.x < 0) {
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        } else {
            transform.localScale = localScale;
        }
    }
}
