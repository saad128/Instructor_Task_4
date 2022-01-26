using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies;
    private float posX = 6;
    private float posZ = 5;
    Vector3 spawnRandomPosition;
    // Start is called before the first frame update
    void Start()
    {
        EnemiesSpawner(numberOfEnemies);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void EnemiesSpawner(int num)
    {
        for (int i = 1; i <= num; i++)
        {
            spawnRandomPosition = new Vector3(Random.Range(-posX, posX), 1.2f, Random.Range(-posZ, posZ));
            Instantiate(enemyPrefab, spawnRandomPosition, enemyPrefab.transform.rotation);
        }
    }

}
