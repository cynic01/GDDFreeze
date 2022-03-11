using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnClick : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Put the UI canvas here")]
    private Canvas enemyUI;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        Debug.Log("clicked on obj");
        if (!enemyUI.enabled) {
            enemyUI.enabled = true;
            Camera.main.transform.position += new Vector3(-5, 0, 0);
        } else {
            enemyUI.enabled = false;
            Camera.main.transform.position += new Vector3(5, 0, 0);
        }
    }
}
