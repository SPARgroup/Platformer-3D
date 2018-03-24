using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour {

    public int zoneIndex;

    public SpawnManager spawnManager;

    public GameObject[] spawnPoints;

    // Use this for initialization
    void Start () {
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) //makes bool of spawnpoints of the current active zone as true (Refer to spawnpoint.cs)
    {
        if(other.tag == "Player")
        {
            spawnManager.currZone = zoneIndex; //zoneIndex switching

            spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

            foreach (GameObject spawnpoint in spawnPoints)
            {
                SpawnPoint pointScript = spawnpoint.GetComponent<SpawnPoint>();

                if (pointScript.parentZone == zoneIndex)
                {
                    pointScript.isActive = true;
                }
                else if(pointScript.parentZone != zoneIndex)
                {
                    pointScript.isActive = false;
                }
            }



            //implement something to stop, populate and start coroutine.
            spawnManager.isSpawning = false;
            Debug.Log("Populating");
            spawnManager.PopulateSpawnPoints();
            Debug.Log("Populated");

            spawnManager.spawningCoroutine = StartCoroutine(spawnManager.spawning(spawnManager.spawnDelay));

            //StartCoroutine(spawnManager.spawningCoroutine);
            
            //StopCoroutine(spawnManager.spawningCoroutine);
            Debug.Log("Zone Number : " + zoneIndex); //just a message
        }
    }
}
//CopyRight SPAR Group
