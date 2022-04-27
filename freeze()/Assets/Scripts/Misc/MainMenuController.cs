using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{   
    #region Initialization
    private void Awake() {
        Cursor.lockState = CursorLockMode.None;
    }
    #endregion

    #region Play Button Methods
    public void PlayArena() {
        SceneManager.LoadScene("WithModels");
    }
    #endregion

    #region General Application Button Methods
    public void Quit() {
        Application.Quit();
    }
    #endregion
}
