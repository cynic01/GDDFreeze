using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Put this script on the CloseCanvas button in EnemyCanvas
public class CloseCanvasButton : MonoBehaviour
{
    private Canvas enemyUI;
    private Vector3 offset = new Vector3(0, 0, 0);
    private CameraController camScript;

    // Start is called before the first frame update
    void Start() {
        enemyUI = transform.parent.GetComponent<Canvas>();
        camScript = Camera.main.GetComponent<CameraController>();
    }

    public void HideCanvas() {
        if (enemyUI.enabled) {
            enemyUI.enabled = false;
            Time.timeScale = 1.0f;
            StartCoroutine(camScript.ShiftCamera(offset));
        }
    }
}
