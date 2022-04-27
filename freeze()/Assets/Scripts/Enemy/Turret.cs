using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Enemy
{

    public GameObject projectile;
    public float timeToReload;
    public float fireSpeed;
    public float radius;

    float reloadTimer = 0;

    #region hackable_variables
    [SerializeField]
    [Tooltip("The object at which this enemy shoots.")]
    private GameObject obj;
    #endregion

    private void Awake()
    {
        reloadTimer = timeToReload;
        obj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        obj = GameObject.FindGameObjectWithTag(attackTag);
        Vector3 obj_position = obj.transform.position;
        obj_position.z = transform.position.z;
        transform.LookAt(obj_position);
        var rotationVector = transform.rotation.eulerAngles;
        if (rotationVector.y - 90 < 1e-2) {
            rotationVector.y = 270;
            rotationVector.x = -rotationVector.x + 180;
        }
        transform.rotation = Quaternion.Euler(rotationVector);

        // Reloading
        if (reloadTimer > timeToReload && inRadius())
        {
            reloadTimer = 0;
            float x = obj.transform.position.x - transform.position.x;
            float y = obj.transform.position.y - transform.position.y;
            Vector2 FireDirection = new Vector2(x, y);
            FireDirection = FireDirection.normalized * fireSpeed;

            GameObject bullet = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
            var bullet_pos = bullet.transform.position;
            bullet.transform.position = new Vector3(bullet_pos.x, bullet_pos.y, 0);
            bullet.GetComponent<Rigidbody>().velocity = FireDirection;
            Destroy(bullet, 5);
        } else {
            reloadTimer += Time.deltaTime;
        }
    }

    bool inRadius() {
        return Vector3.Distance(obj.transform.position, transform.position) < radius;
    }

    public void ChangeTarget(GameObject target) {
        obj = target;
    }

    public override void Attack(GameObject other)
    {
        
    }
}

