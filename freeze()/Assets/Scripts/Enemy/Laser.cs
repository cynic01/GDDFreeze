using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    private int damage = 5;
    private LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position + new Vector3(0, 0, -30));
    }

    void OnTriggerEnter(Collider coll) {
        if (coll.gameObject.tag == "Player") {
            Player player = coll.GetComponent(typeof(Player)) as Player;
            player.TakeDamage(damage);
        }
    }
}
