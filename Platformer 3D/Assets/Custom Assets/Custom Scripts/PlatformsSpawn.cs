using System.Collections;
using UnityEngine;

public class PlatformsSpawn : MonoBehaviour {

    public int maxPlatforms = 50;
    public int currentPlatforms = 0;
    public int numberOfSpawnPoints = 3;

    public float platformSpeed = 5f;
    public float spawnTimeDifference = 1.2f;

    public GameObject endPoint;
    public GameObject Platform;

    GameObject[] spawnPoints = new GameObject[3];

    IEnumerator SpawningPlatformsCoroutine;

    void Start()
    {
        int i = 0;
       foreach(GameObject point in transform)
        {
            spawnPoints[i] = point;
            i++;
        }
        SpawningPlatformsCoroutine = SpawnCoroutine(spawnPoints , maxPlatforms, currentPlatforms);
        StartCoroutine(SpawningPlatformsCoroutine);

    }

    public IEnumerator SpawnCoroutine(GameObject[] spawnPoints, int maxPlatforms, int currentPlatforms)
    {
        yield return new WaitForSeconds(spawnTimeDifference);
        if(currentPlatforms < maxPlatforms)
        {
            GameObject platform = Instantiate(Platform, gameObject.transform.position, gameObject.transform.rotation);
            Vector3 endPos = new Vector3(endPoint.transform.position.x, endPoint.transform.position.y, endPoint.transform.position.z);
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, endPos, platformSpeed * Time.deltaTime);
        }
    }

}
