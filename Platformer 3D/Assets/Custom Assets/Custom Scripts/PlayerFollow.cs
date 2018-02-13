using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {
    public GameObject target;
    public float enemySpeed = 2f;
    private Vector3 playerPos;
    private bool reachedPlayer = false;

	// Use this for initialization
	//void Start () {

        

	//}
    
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(target.transform);



        if (reachedPlayer == false)
        {
            playerPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, playerPos, enemySpeed * Time.deltaTime);
        }

	}
}
