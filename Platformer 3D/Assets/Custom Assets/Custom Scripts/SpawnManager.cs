using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {


    //this is the script for the spawn manager

    public int totalEnemiesToBeSpawned = 0; //total enemies to be spawned
    public int enemiesSpawnedThisRound = 0; //enemies spawned till now in this round
    public int totalEnemiesSpawned = 0; //total enemies spawned since the start of eternity xD
    public int numOfSpawnPoints = 4; //increase this if more spawnpoints are added and make the new spawnpoints as a child of the SpawnManager gameobject
    public float spawnDelay = 2f; //seconds to wait before spawning another enemy

    public bool levelComplete = false; //just a bool to be set true when level is completed 

    public GameObject enemy; //enemy ref.

    public int maxEnemiesInSceneAtOnce; //number of enemies to be in the scene at an instant (Different from totalEnemiesToBeSpawned)
    public int enemiesInScene = 0; //current number of enemies

    public IEnumerator spawningCoroutine;
    public GameObject[] spawnPoints;


	// Use this for initialization
	void Start () {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        spawningCoroutine = spawning(spawnDelay); //initialising coroutine
        StartCoroutine(spawningCoroutine); //starting coroutine
	}

    public IEnumerator spawning(float delay)
    {
        //will keep the coroutine running till this condition is met
        while (enemiesSpawnedThisRound < totalEnemiesToBeSpawned)
        {
            yield return new WaitForSeconds(delay);

            //spawn an enemy only when enemiesinscene is less than allowed number of enemies in a scene at once
            if (enemiesInScene < maxEnemiesInSceneAtOnce)
            {
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)].transform;
                Instantiate(enemy, randomSpawnPoint.position, randomSpawnPoint.rotation);
                enemiesSpawnedThisRound++;
                enemiesInScene++; //number of enemies is also decreased when an enemy is killed. Refer to the EnemyAI script
                totalEnemiesSpawned++;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    //Copyright Samarth Singla.
}
