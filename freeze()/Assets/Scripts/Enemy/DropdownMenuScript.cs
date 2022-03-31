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
    private GameObject enemyGO;

    // Start is called before the first frame update
    void Start()
    {
        dropdown = gameObject.GetComponent<TMP_Dropdown>();
        title = transform.parent.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        enemyGO = transform.parent.parent.parent.parent.gameObject;
        Debug.Log(enemyGO);
    }

    public void OnSelect(BaseEventData eventData) {
        // Debug.Log(dropdown.captionText.text);
        switch(title.text) {
            case "If Detect":
                if (dropdown.captionText.text == "Player") {
                    // Enemy detects player
                    Debug.Log(title.text);
                } else if (dropdown.captionText.text == "Enemy") {
                    // Enemy detects another enemy
                    ;
                }
                break;
            case "Chase":
                if (dropdown.captionText.text == "Player") {
                    // Enemy chase the player
                    ;
                } else if (dropdown.captionText.text == "Enemy") {
                    // Enemy chase another enemy
                    ;
                }
                break;
            default:
                Debug.Log("Error in Dropdown Menu");
                break;
        }
        
    }
}
