using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float reboundAmount = 2f;
    public float reboundSpeed = 2f;

    public bool isRebounding = false;

    public int counter = 0;

    Vector3 finalPos;
    Vector3 originalPos;

    public Coroutine reboundCoroutine;

    private void OnTriggerEnter(Collider other) //ENTER
    {
        if (other.tag == "Player")
        {
            finalPos = new Vector3(this.transform.position.x, this.transform.position.y - reboundAmount, this.transform.position.z);
            originalPos = transform.position;
            Debug.Log("player aa gaya");
            isRebounding = true;
            //reboundCoroutine = StartCoroutine(Rebound(reboundSpeed, reboundAmount));

        }
    }

    private void OnTriggerExit(Collider other) //EXIT
    {
        if (other.tag == "Player")
        {
            counter = 0;
            isRebounding = false;
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        /* if (isRebounding)
         {
             Vector3.Lerp(transform.position, finalPos,Time.deltaTime);
         }

         if(transform.position == finalPos && counter < 2)
         {
             finalPos = originalPos;
             counter += 1; 
         }
     }

     public IEnumerator Rebound(float speed, float amount)
     {


     }*/
    }
}
