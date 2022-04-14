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
    [Tooltip("The object at which this enemy shoots.")]
    private GameObject obj;
    #endregion

    private void Awake()
    {
        reloadTimer = timeToReload;
        obj = GameObject.Find("U");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 obj_position = obj.transform.position;
        obj_position.z = transform.position.z;
        // transform.rotation = Quaternion.LookRotation(transform.position - obj.transform.position);
        transform.LookAt(obj_position);
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y = -90;
        if (90 < rotationVector.x && rotationVector.x < 270) {
            rotationVector.x = 180 - rotationVector.x;
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
        } else
        {
            reloadTimer += Time.deltaTime;
        }
    }

    bool inRadius() {
        return Vector3.Distance(obj.transform.position, transform.position) < radius;
    }

    public void ChangeTarget(GameObject target) {
        obj = target;
    }
}

