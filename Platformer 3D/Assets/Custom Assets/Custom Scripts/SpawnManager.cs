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
    public bool isSpawning = true;

    public GameObject enemy; //enemy ref.

    public GameObject[] activeSpawnPoints;

    public int maxEnemiesInSceneAtOnce; //number of enemies to be in the scene at an instant (Different from totalEnemiesToBeSpawned)
    public int enemiesInScene = 0; //current number of enemies

    public int currZone;

    public Coroutine spawningCoroutine;
    public GameObject[] spawnPoints;

    public List<GameObject> currSpawnPoints = new List<GameObject>();


	// Use this for initialization
	void Start () {
        spawningCoroutine = StartCoroutine(spawning(spawnDelay)); //initialising coroutine
        //StartCoroutine(spawningCoroutine); //starting coroutine
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
                Transform randomSpawnPoint = activeSpawnPoints[Random.Range(0, activeSpawnPoints.Length - 1)].transform;

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

    public void PopulateSpawnPoints()
    {
        //spawnPoints = GameObject.FindGameObjectsWithTag(tag);
        
        GameObject[] allSpawnPoints = new GameObject[50];
        
        int activeCounter = 0;
       // int allCounter = 0;
       

        allSpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        int maxLimit = allSpawnPoints.Length;

        //for(int i = 0; i < maxLimit; i++)
        //{
        //    if(allSpawnPoints[i].GetComponent<SpawnPoint>().isActive == true)
         //   {
         //       activeSpawnPoints[activeCounter] = allSpawnPoints[i];
         //       activeCounter++;
         //   }
       // }

        foreach(GameObject point in allSpawnPoints)
        {
            
            if (point.GetComponent<SpawnPoint>().isActive == true)
            {
                activeSpawnPoints[activeCounter] = point;
                activeCounter++;
            }


        }
    }

    // TO BE DONE: Properly stop the coroutine from Zone script and populate and then Start the coroutine again.
    //Copyright SPAR Group
}
