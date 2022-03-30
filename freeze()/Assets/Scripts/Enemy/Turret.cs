using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public GameObject projectile;
    public float timeToReload;
    public float fireSpeed;
    public string targetTag;

    float reloadTimer = 0;

    List<GameObject> playerList;

    private void Awake()
    {
        playerList = new List<GameObject>();
        targetTag = "Player";
        reloadTimer = timeToReload;
    }

    // Update is called once per frame
    void Update()
    {
        if (reloadTimer > timeToReload)
        {
            if (playerList.Count > 0)
            {
                reloadTimer = 0;
                foreach (GameObject obj in playerList)
                {
                    float x = obj.transform.position.x - transform.position.x;
                    float y = obj.transform.position.y - transform.position.y;
                    Vector2 FireDirection = new Vector2(x, y);
                    FireDirection = FireDirection.normalized * fireSpeed;

                    GameObject newProjectile = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
                    newProjectile.GetComponent<Rigidbody>().velocity = FireDirection;
                    Destroy(newProjectile, 5);
                }
            }
        } else
        {
            reloadTimer += Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (isPlayer(coll.gameObject))
        {
            playerList.Add(coll.gameObject);
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        playerList.Remove(coll.gameObject);
    }

    bool isPlayer(GameObject obj)
    {
        return obj.CompareTag(targetTag);
    }
}

