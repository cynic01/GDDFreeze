using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public GameObject projectile;
    public float timeToReload;
    public float fireSpeed;
    public string targetTag;
    public float radius;

    float reloadTimer = 0;

    List<GameObject> playerList;

    #region hackable_variables
    [SerializeField]
    [Tooltip("The angle at which this enemy shoots.")]
    public GameObject obj;
    #endregion

    #region angle_variables
    double epsilon = 1.0e-5;
    float rotation_speed = 5.0f;
    #endregion

    private void Awake()
    {
        playerList = new List<GameObject>();
        targetTag = "Player";
        reloadTimer = timeToReload;
        obj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion obj_pos = obj.transform.rotation;
        if (Quaternion.Dot(obj_pos, transform.rotation) < epsilon) {
            var step = rotation_speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, obj_pos,  step);
        }
        if (reloadTimer > timeToReload 
            && Vector3.Distance(obj.transform.position, transform.position) < radius)
        {
            reloadTimer = 0;
            float x = obj.transform.position.x - transform.position.x;
            float y = obj.transform.position.y - transform.position.y;
            Vector2 FireDirection = new Vector2(x, y);
            FireDirection = FireDirection.normalized * fireSpeed;

            GameObject newProjectile = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
            newProjectile.GetComponent<Rigidbody>().velocity = FireDirection;
            Destroy(newProjectile, 5);
        } else
        {
            reloadTimer += Time.deltaTime;
        }
    }
}

