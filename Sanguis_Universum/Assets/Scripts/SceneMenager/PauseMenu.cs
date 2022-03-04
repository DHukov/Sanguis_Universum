using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuState { Play, Pause, }
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public MenuState menuState;
    public void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && menuState == MenuState.Play)
            Pause();
        else if (Input.GetKeyDown(KeyCode.Escape) && menuState == MenuState.Pause)
            Resume();
    }

    public void Resume()
    {
        menuState = MenuState.Play;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    
    void Pause()
    {
        menuState = MenuState.Pause;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    [System.Obsolete]
    public void QutToMainMenu()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(0);
    }
}
