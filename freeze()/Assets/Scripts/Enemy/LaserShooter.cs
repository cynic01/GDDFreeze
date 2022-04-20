using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : Enemy
{
    #region movement_variables
	[SerializeField]
	[Tooltip("Speed of the enemy.")]
	public float movespeed;
	#endregion

    #region attack_variables
    [SerializeField]
	[Tooltip("Laser prefab.")]
    public GameObject laser;

    public float timeToReload;

    private float epsilon = 0.2f;
    private float epsilonTime = 0.05f;
    private float reloadTimer;
    private float shootingTimer;
    private float timeToShoot = 2;
    #endregion

	// Use this for initialization
	void Start () {
		on = true;
		maxHealth = 100;
		curHealth = maxHealth;

        reloadTimer = 0;
        shootingTimer = 0;
	}

    void Update() {
        Debug.Log("SHOOT: " + shootingTimer);
        // Debug.Log("RELOAD " + reloadTimer);
    }

	public override void Attack(GameObject other) 
    {
        if (shootingTimer > timeToShoot) {
            
            reloadTimer = 0;

        } else {

            GameObject laser_obj = (GameObject)Instantiate(laser, transform.position, transform.rotation);
            var laser_pos = laser_obj.transform.position;
            laser_obj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1000);
            Destroy(laser_obj, 0.1f);

            shootingTimer += Time.deltaTime;
        }
	}

    void Chase(GameObject other) 
    {
        Vector3 player_pos = other.transform.position;
        Vector3 player_xy = new Vector3(player_pos.x, player_pos.y, 0);
        Vector3 this_xy = new Vector3(transform.position.x, transform.position.y, 0);
        if (Vector3.Distance(player_xy, this_xy) > epsilon) {
            Vector3 direction = (player_xy - this_xy).normalized;
		    transform.position += direction * movespeed * Time.deltaTime;
        }

        if (reloadTimer > timeToReload) {
            if (reloadTimer - timeToReload < epsilonTime) {
                shootingTimer = 0;
            }
            Attack(other);
        }
        reloadTimer += Time.deltaTime;
    }

    void OnTriggerStay(Collider collision)
    {
        if (on && collision.gameObject.tag == chaseTag) {
            Chase(collision.gameObject);
        }
    }
}
