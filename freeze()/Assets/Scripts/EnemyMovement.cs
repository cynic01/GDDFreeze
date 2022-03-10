using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField]
    [Tooltip("Is this enemy moving.")]
    bool moving;

	// Use this for initialization
	void Start () {
        moving = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerStay(Collider collision)
    {
		if (!moving) {
			moving = true;
			StartCoroutine(Investigate(collision.gameObject.GetComponent<Transform>().position));
		}
    }

	IEnumerator Investigate(Vector3 endPos) {
		Vector3 startPos = transform.position;
		float elapsedTime = 0;
		while (Vector3.Distance(transform.position, endPos) > Vector3.kEpsilon) {
			transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / 2);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		moving = false;
	}
}
