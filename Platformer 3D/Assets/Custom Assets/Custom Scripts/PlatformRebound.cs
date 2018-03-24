using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRebound : MonoBehaviour {


    public Animator platformAnimator;
    
	// Use this for initialization
	void Start () {
        platformAnimator = this.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		



	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            platformAnimator.Play("PlatformRebound",-1, 0f);
        }
    }
}
