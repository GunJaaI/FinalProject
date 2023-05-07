using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour {
    public float timeToLive = 0.5f;
    public float floatSpeed = 200f;
    public Vector3 floatDirection = new Vector3(0, 1, 0);
    public TextMeshProUGUI textMesh;
    //public TMP_Text stringAmount;

    RectTransform reactTransform;
    Color startingColor;
    float timeElapsed = 0.0f;
    // Start is called before the first frame update
    void Start() {
        reactTransform = GetComponent<RectTransform>();
        startingColor = textMesh.color;
    }

    // Update is called once per frame
    void Update() {
        timeElapsed += Time.deltaTime;

        reactTransform.position += floatDirection * floatSpeed * Time.deltaTime;

        textMesh.color = new Color(startingColor.r, startingColor.g, startingColor.b, 1- (timeElapsed / timeToLive));

        if (timeElapsed > timeToLive) {
            Destroy(gameObject);
        }
    }

    public void ChangeTextPopup(int amount) { //ยังทำไม่ได้
        //stringAmount.SetText(amount.ToString());
        textMesh.text = amount.ToString();
        //textMesh.text = stringAmount;
    }
}
