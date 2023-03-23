using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakeShape : MonoBehaviour {
    public int numPointsLeft = 1;
    public int numPointsRight = 6;
    public float radiusLeft = 0.1f;
    public float radiusRight = 0.2f;
    
    public float thicknessLeft = 0.1f;
    public float thicknessRight = 0.15f;
    //public Color color = Color.white;
    public float xLeft = -1f;
    public float xRight = 1f;
    public float yUp = -1f;
    public float yDown = -1f;
    public float rotationSpeedXLeft = 10f; // Rotation speed X
    public float rotationSpeedXRight = 10f;
    public float rotationSpeedZLeft = 10f; // Rotation speed Z
    public float rotationSpeedZRight = 10f;
    private float currentRotation = 0f; // Current rotation snowflake

    private LineRenderer lineRenderer;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<LineRenderer>().enabled = true; // Enable the LineRenderer
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(Random.Range(xLeft, xRight), yUp);

        lineRenderer = GetComponent<LineRenderer>();

        int numPoints = Random.Range(numPointsLeft, numPointsRight); // Random Shape value snowflake
        float radius = Random.Range(radiusLeft, radiusRight); // Random Radius value snowflake
        float thickness = Random.Range(thicknessLeft, thicknessRight); // Random Thickness value snowflake
        Color color = new Color(92f, 226f, 255f, Random.Range(0.25f, 0.75f)); // Random Opacity for Linerenderer

        // Calculate the points of the snowflake shape
        Vector3[] points = new Vector3[numPoints * 2];
        float angle = 360f / numPoints; // int angle = 360 / numPoints;

        for (int i = 0; i < numPoints; i++) {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle * i) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle * i) * radius;
            points[i * 2] = new Vector3(x, y, 0f);

            x = Mathf.Sin(Mathf.Deg2Rad * angle * i + angle / 2f) * (radius - thickness);
            y = Mathf.Cos(Mathf.Deg2Rad * angle * i + angle / 2f) * (radius - thickness);
            points[i * 2 + 1] = new Vector3(x, y, 0f);
        }

        // Set the line renderer properties
        lineRenderer.positionCount = points.Length;
        lineRenderer.SetPositions(points);
        lineRenderer.startWidth = thickness;
        lineRenderer.endWidth = thickness;
        lineRenderer.material.color = color;

    }

    void Update() {
        if (transform.position.y < yDown)
        {
            Destroy(gameObject);
            //GetComponent<LineRenderer>().enabled = false; // Disable the LineRenderer
        }
        float rotationSpeedX = Random.Range(rotationSpeedXLeft, rotationSpeedXRight); // Random RotationXAxis value snowflake
        float rotationSpeedZ = Random.Range(rotationSpeedZLeft, rotationSpeedZRight);
        currentRotation += rotationSpeedX * Time.deltaTime; // Rotate the snowflake
        currentRotation += rotationSpeedZ * Time.deltaTime;
        if (currentRotation >= 360f) {
            currentRotation -= 360f;
        }
        lineRenderer.transform.rotation = Quaternion.Euler(currentRotation, 0f, currentRotation);
    }
}
