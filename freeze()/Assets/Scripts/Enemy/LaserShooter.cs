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

    private bool laserOn;
    #endregion

	// Use this for initialization
	void Start () {
		on = true;
		maxHealth = 100;
		curHealth = maxHealth;

        reloadTimer = 0;
        shootingTimer = 0;

        laserOn = false;
	}

    void Update() {
        // Debug.Log("SHOOT: " + shootingTimer);
        // Debug.Log("RELOAD " + reloadTimer);

        if (reloadTimer > timeToReload) {
            if (reloadTimer - timeToReload < epsilonTime) {
                shootingTimer = 0;
            }
            Attack(null);
        }
        reloadTimer += Time.deltaTime;
    }

	public override void Attack(GameObject other) 
    {
        if (shootingTimer > timeToShoot) {

            laserOn = false;
            
            reloadTimer = 0;

        } else {
            if (!laserOn) {
                GameObject laser_obj = (GameObject)Instantiate(laser);
                laser_obj.transform.position += new Vector3(6f, -2f, 5);
                Destroy(laser_obj, timeToShoot);

                laserOn = true;
            }

            shootingTimer += Time.deltaTime;
        }
	}

    void Chase(GameObject other) 
    {
        // Vector3 player_pos = other.transform.position;
        // Vector3 player_xy = new Vector3(player_pos.x, player_pos.y, 0);
        // Vector3 this_xy = new Vector3(transform.position.x, transform.position.y, 0);
        // if (Vector3.Distance(player_xy, this_xy) > epsilon) {
        //     Vector3 direction = (player_xy - this_xy).normalized;
		//     transform.position += direction * movespeed * Time.deltaTime;
        // }

        // if (reloadTimer > timeToReload) {
        //     if (reloadTimer - timeToReload < epsilonTime) {
        //         shootingTimer = 0;
        //     }
        //     Attack(other);
        // }
        // reloadTimer += Time.deltaTime;
    }

    // void OnTriggerStay(Collider collision)
    // {
    //     if (on && collision.gameObject.tag == attackTag) {
    //         Chase(collision.gameObject);
    //     }
    // }
}
