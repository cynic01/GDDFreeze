using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DropdownMenuScript : MonoBehaviour, ISelectHandler
{
    private TMP_Dropdown dropdown;
    private TMP_Text title;
    private Enemy enemyScript;

    // Start is called before the first frame update
    void Start() {
        dropdown = gameObject.GetComponent<TMP_Dropdown>();
        title = transform.parent.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(title.text);
        enemyScript = transform.parent.parent.parent.parent.gameObject.GetComponent<Enemy>();
    }

    public void OnSelect(BaseEventData eventData) {
        Debug.Log(title.text);
        switch(title.text) {
            case "If Detect":
                enemyScript.ChangeDetectionTag(dropdown.captionText.text);
                break;
            case "Attack":
                enemyScript.ChangeAttackTag(dropdown.captionText.text);
                break;
            case "Route":
                // enemyScript.ChangeRoute(name, dropdown.captionText.text);
                break;
            default:
                Debug.Log("Error in Dropdown Menu Script");
                break;
        }
        
    }
}
