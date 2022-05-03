using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Put this script on enemy objects that have EnemyCanvas
public class ShowOnClick : MonoBehaviour
{
    private Canvas enemyUI;
    private Vector3 offset = new Vector3(-2, 0, 0);
    private CameraController camScript;
    
    // Start is called before the first frame update
    void Start() {
        enemyUI = gameObject.transform.Find("EnemyCanvas" + name).GetComponent<Canvas>();
        enemyUI.enabled = false;
        camScript = Camera.main.GetComponent<CameraController>();
    }

    private void OnMouseDown() {
        if (!enemyUI.enabled) {
            StartCoroutine(camScript.ShiftCamera(offset));
            enemyUI.enabled = true;
            AudioSource m_audiosource = Camera.main.GetComponent<AudioSource>();
            m_audiosource.volume /= 2;
            Time.timeScale = 0.1f;
        }
    }
}
