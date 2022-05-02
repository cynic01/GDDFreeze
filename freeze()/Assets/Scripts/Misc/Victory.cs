using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    #region Initialization
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    #endregion

    void Update()
    {
        if (Input.anyKey)
        {
            PlayArena();
        }
    }

    #region Play Button Methods
    public void PlayArena()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion

    #region General Application Button Methods
    public void Quit()
    {
        Application.Quit();
    }
    #endregion
}
