using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private float spawnPosX = 0f;
    private float spawnPosY = 6f;
    private float spawnInterval = 1.8f;

    private GameManager gameManager;
    
    void Start()
    {
        //gamemanager bind to player
        gameManager = GameObject.Find("Player").GetComponent<GameManager>();
        StartCoroutine(SpawnObstacles());
    }

    //not the best use of coroutine, but...
    IEnumerator SpawnObstacles()
    {
        while (gameManager.isGameActive)
        {
            yield return new WaitForSecondsRealtime(spawnInterval);
            Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
        }
    }
}
