using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    private GameObject Target;
    public float moveSpeed = 2f;
    public float minDistance = 2f;
    public float distanceFromPlayer;
    public float hitFreq = 0.5f;
    public int damageOverTimeAmount = 10;
    public bool isDamaging = false;

    public IEnumerator damageOverTimecoroutine; 
    public HealthSystem hs;

	// Use this for initialization
	void Start ()
    {

        Target = GameObject.FindGameObjectWithTag("Player");

        //error handling
		if (Target == null)
        {
            Debug.Log("Enemy says : Who should I follow? You havenot set my target");
        }

        hs = Target.GetComponent<HealthSystem>();
        damageOverTimecoroutine = damageOverTime(damageOverTimeAmount, hitFreq);
        StartCoroutine(damageOverTimecoroutine);
	}

	// Update is called once per frame
	void Update ()
    {
        
        //what is the distance from the player?
        distanceFromPlayer = Vector3.Distance(Target.transform.position, transform.position); //calculates dist b/w 2 transforms

        transform.LookAt(Target.transform);
        //chase only if distance is less than the specified min distance


        if (distanceFromPlayer > minDistance)
        {
            isDamaging = false;
            Chase(moveSpeed);
        }
        else
        {
            //start sending damage
            isDamaging = true;
            Debug.Log(" I am hurting the player!");
        }
	}


    //revise this method
 

    public void Chase(float speed)
    {
        //follow the player at a fixed speed
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, moveSpeed *Time.deltaTime);
    }

    public IEnumerator damageOverTime(int amount, float freq)
    {
        while (hs.health > 0)
        {
            yield return new WaitForSeconds(1 / freq);
            if (isDamaging == true)
            {
                hs.health -= amount;
            }
        }
    }

   
}
