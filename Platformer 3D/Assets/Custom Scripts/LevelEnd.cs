using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour {

   
   private BoxCollider componentcollider;


	// Use this for initialization
	void Start () {
        componentcollider = this.GetComponent<BoxCollider>();
       	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("YAYAYAYA");
        }
    }
}
