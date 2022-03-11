using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCollider : MonoBehaviour
{
    public GameObject curTouch;
    bool isFloor(GameObject obj)
    {
        return obj.layer == LayerMask.NameToLayer("Floor")
            || obj.CompareTag("Floor");
    }

    private void OnTriggerEnter(Collider other)
    {
        curTouch = other.gameObject;
        GetComponentInParent<Player>().onGround = isFloor(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        curTouch = null;
        GetComponentInParent<Player>().onGround = false;
    }
}
