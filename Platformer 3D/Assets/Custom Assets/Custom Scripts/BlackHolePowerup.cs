using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHolePowerup : MonoBehaviour {


    public GameObject blackHole;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            blackHole.SetActive(true);
            Destroy(gameObject);
        }
    }
}
