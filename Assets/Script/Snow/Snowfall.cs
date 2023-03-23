using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowfall : MonoBehaviour {
    public GameObject snowflakeShapePrefab;

    void Start() {
        //InvokeRepeating("SpawnSnowflake", 0f, 0.5f);
        InvokeRepeating("SpawnSnowflakeShape", 0f, 0.5f);
    }

    // void SpawnSnowflake()
    // {
    //     float xPos = Random.Range(-9f, 9f);
    //     Vector3 spawnPos = new Vector3(xPos, 7f, 0f);

    //     GameObject snowflake = Instantiate(snowflakePrefab, spawnPos, Quaternion.identity);
    //     snowflake.transform.parent = transform;
    // }

    void SpawnSnowflakeShape() {
        float xPos = Random.Range(-9f, 9f);
        Vector3 spawnPos = new Vector3(xPos, 7f, 0f);

        GameObject snowflake = Instantiate(snowflakeShapePrefab, spawnPos, Quaternion.identity);
        snowflake.transform.parent = transform;
    }
}
