using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The Player-controlled GameObject.")]
    public GameObject player;

    [SerializeField]
    [Tooltip("Animation time taken to move the camera")]
    private float cameraTotalMoveTime = 0.5f;

    private Vector3 offset;
    private Vector3 shiftOffset = new Vector3(0, 0, 0);
    private bool cameraMoving = false;

    void Start() {
        // player.transform.position is usually (0, 0, 0) at the start
        offset = transform.position - player.transform.position;
    }

    void LateUpdate() {
        transform.position = player.transform.position + offset + shiftOffset;
    }

    public IEnumerator ShiftCamera(Vector3 pos) {
        float timeElapsed = 0f;
        while (timeElapsed <= cameraTotalMoveTime) {
            shiftOffset = Vector3.Lerp(shiftOffset, pos, timeElapsed / cameraTotalMoveTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}