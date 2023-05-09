using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] public GameObject parentEnemy;

    [SerializeField] public GameObject EnemyBirth;

    [SerializeField] public float EnemyInterval;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SpawnEnemy(EnemyInterval, EnemyBirth, parentEnemy));
    }

    // Update is called once per frame
    void Update() {

    }
    private IEnumerator SpawnEnemy(float interval, GameObject enemy, GameObject parentEnemy) {
        Vector3 parentPos = parentEnemy.transform.position;
        Vector3 spawnPos = parentPos + new Vector3(Random.Range(-5f,5f),Random.Range(-5f,5f),0f);

        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, spawnPos, Quaternion.identity);
        StartCoroutine(SpawnEnemy(interval, enemy, newEnemy));

    }
}
