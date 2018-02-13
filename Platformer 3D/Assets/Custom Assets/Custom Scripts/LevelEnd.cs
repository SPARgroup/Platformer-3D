using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour {

   


	// Use this for initialization
	void Start () {
        
       	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //load scene and other stuff needeed
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("YAYAYAYA");
        }
    }
}
