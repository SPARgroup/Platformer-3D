using UnityEngine;

public class PlayerFollow : MonoBehaviour {
    public GameObject target;
    public float enemySpeed = 2f;
    private Vector3 playerPos;
    private bool reachedPlayer = false;

	// Use this for initialization
	void Start () {

        target = GameObject.FindGameObjectWithTag("Player");

	}

	
	// Update is called once per frame
	void Update () {
        if (reachedPlayer == false)
        {
            playerPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, playerPos, enemySpeed * Time.deltaTime);
        }

	}
}
