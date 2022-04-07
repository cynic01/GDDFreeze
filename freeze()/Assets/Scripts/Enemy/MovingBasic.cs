using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBasic : MonoBehaviour
{

    #region positions
    public List<GameObject> targets;
    private List<Vector3> positions;
    private float movespeed = 10;
    private int next_index;
    private int numLocations;
    #endregion

    #region attack_variables
    private float damage = 1;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject target in targets) {
            positions.Add(target.transform.position);
        }
        numLocations = positions.Count;
        next_index = 1 % numLocations;
        transform.position = positions[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(positions[next_index], transform.position) < Vector3.kEpsilon) {
            next_index = (next_index + 1) % numLocations;
            StartCoroutine(MoveToPosition(positions[next_index]));
            next_index += 1;
        }
    }

    public void Attack(GameObject other) {
        Player player = other.GetComponent(typeof(Player)) as Player;
        player.TakeDamage(damage);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Attack(other.gameObject);
        }
    }

    IEnumerator MoveToPosition(Vector3 endPos) {
		Vector3 startPos = transform.position;
		float elapsedTime = 0;
		while (Vector3.Distance(transform.position, endPos) > Vector3.kEpsilon) {
			transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / 2);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}
}
