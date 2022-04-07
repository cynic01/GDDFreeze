using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public GameObject projectile;
    public float timeToReload;
    public float fireSpeed;
    public float radius;

    float reloadTimer = 0;

    #region hackable_variables
    [SerializeField]
    [Tooltip("The angle at which this enemy shoots.")]
    public GameObject obj;
    #endregion

    private void Awake()
    {
        reloadTimer = timeToReload;
        obj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 obj_position = obj.transform.position;
        obj_position.z = transform.position.z;
        transform.LookAt(obj_position);
        transform.Rotate(180, 90, 0);
        if (reloadTimer > timeToReload && inRadius())
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

    bool inRadius() {
        return Vector3.Distance(obj.transform.position, transform.position) < radius;
    }
}

