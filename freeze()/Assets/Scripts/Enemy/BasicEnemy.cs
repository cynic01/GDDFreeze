using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour {
	#region hackable_variables
	[SerializeField]
    [Tooltip("Is this enemy tracking the player.")]
    public bool on;

	[SerializeField]
	[Tooltip("What object tag is the enemy chasing.")]
	private string chaseTag;
	#endregion

	#region movement_variables
	[SerializeField]
    [Tooltip("Speed of the enemy.")]
    float movespeed;
	#endregion

	// Use this for initialization
	void Start () {
        on = true;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerStay(Collider collision)
    {
		if (on && collision.gameObject.tag == chaseTag) {
			var direction = (collision.gameObject.transform.position - transform.position).normalized;
			transform.position += direction * movespeed * Time.deltaTime;
		}
    }
}
