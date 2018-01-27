using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject enemy;
	// Use this for initialization
	void Start () {
        Vector3 randomPos = new Vector3(0, 0, 0);
        randomPos.x = Mathf.Sin(Time.time);
        Instantiate(enemy, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
