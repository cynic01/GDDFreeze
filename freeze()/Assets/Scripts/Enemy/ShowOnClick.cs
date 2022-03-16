using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnClick : MonoBehaviour
{
    private bool cameraMoving;
    private Canvas enemyUI;

    [SerializeField]
    [Tooltip("Animation time taken to move the camera")]
    private float cameraTotalMoveTime = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyUI = gameObject.transform.Find("EnemyCanvas").GetComponent<Canvas>();
        enemyUI.enabled = false;
    }

    private void OnMouseDown() {
        if (!cameraMoving) {
            if (!enemyUI.enabled) {
                enemyUI.enabled = true;
                Vector3 targetPos = Camera.main.transform.position - new Vector3(5, 0, 0);
                StartCoroutine(ShiftCamera(targetPos));
            } else {
                enemyUI.enabled = false;
                Vector3 targetPos = Camera.main.transform.position + new Vector3(5, 0, 0);
                StartCoroutine(ShiftCamera(targetPos));
            }
        }
    }

    IEnumerator ShiftCamera(Vector3 pos) {
        float timeElapsed = 0f;
        cameraMoving = true;
        while (timeElapsed <= cameraTotalMoveTime) {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, pos, timeElapsed / cameraTotalMoveTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        cameraMoving = false;
    }
}
