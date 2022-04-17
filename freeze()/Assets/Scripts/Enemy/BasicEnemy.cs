using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//if this catastrophically fails, change the line below to
//BasicEnemy : MonoBehavior instead of : Enemy
public class BasicEnemy : Enemy {
	#region movement_variables
	[SerializeField]
	[Tooltip("Speed of the enemy.")]
	float movespeed;
	#endregion

	// Use this for initialization
	void Start () {
		on = true;
		maxHealth = 100;
		curHealth = maxHealth;
	}

	public override void Attack(GameObject other) {
		if (on && other.tag == attackTag) {
			Vector3 direction = (other.transform.position - transform.position).normalized;
			transform.position += direction * movespeed * Time.deltaTime;
		}
	}

    void OnTriggerStay(Collider collision)
    {
		Attack(collision.gameObject);
    }
}
