using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

   /* public int damageperhit = 20;
    public float hitfreq = 0.5f;
    private float origEnemySpeed = 0;
    public bool isDamaging = false;


    private IEnumerator coroutine;

    private void Start()
    {
        PlayerFollow pf = GetComponent<PlayerFollow>();
        origEnemySpeed = pf.enemySpeed;
    }

    void OnTriggerEnter(Collider col)
    {
        PlayerFollow pf = GetComponent<PlayerFollow>();
        pf.enemySpeed = 0;

        coroutine = DamageOverTime(damageperhit, hitfreq, col);
        StartCoroutine(coroutine);

        isDamaging = true;

        HealthSystem hs = col.gameObject.GetComponent<HealthSystem>();
        hs.isBeingDamaged = true;
        hs.p_coroutine = hs.HealOverTime(hs.healAmount, hs.healfreq);
        StopCoroutine(hs.p_coroutine);
    }

    public IEnumerator DamageOverTime(int dph, float hf, Collider localcol)
    {
        HealthSystem hs = localcol.GetComponent<HealthSystem>();
        while (hs.health > 0 && isDamaging == true)
        {
            hs.health -= damageperhit;
            yield return new WaitForSeconds(1/hitfreq);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(coroutine);

        PlayerFollow pf = GetComponent<PlayerFollow>();
        pf.enemySpeed = origEnemySpeed;

        isDamaging = false;

        HealthSystem hs = other.gameObject.GetComponent<HealthSystem>();
        hs.isBeingDamaged = false;
        hs.p_coroutine = hs.HealOverTime(hs.healAmount, hs.healfreq);
        StartCoroutine(hs.p_coroutine);

    }

*/
}
