using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {

    public int health = 100;
    public bool isBeingDamaged = false;
    public int healAmount = 10;
    public float healfreq = 0.5f;
    public bool isHealing = false;

    public IEnumerator p_coroutine;

	// Use this for initialization
	void Start () {
       // coroutine = HealOverTime(healAmount, healfreq);
       // StartCoroutine(coroutine);
    }
    
    // Update is called once per frame
    void Update () {
        if (health <= 0)
        {
            Debug.Log("Mar gaya bhai");
        }
        
    }

    public IEnumerator HealOverTime(int amount, float freq)
    {
        while (health < 100 && isBeingDamaged == false)
        {
            yield return new WaitForSeconds(1 / freq);
            health += amount;
            isHealing = true;        
        }
        
    }
}
