using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	[SerializeField]
    [Tooltip("Is this enemy tracking the player.")]
    public bool on;

	[SerializeField]
    [Tooltip("Is this enemy tracking the player.")]
    float movespeed;

	// Use this for initialization
	void Start () {
        on = true;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerStay(Collider collision)
    {
		if (on && collision.gameObject.tag == "Player") {
			transform.position += (collision.gameObject.transform.position - transform.position) 
											* movespeed * Time.deltaTime;
		}
    }
}
