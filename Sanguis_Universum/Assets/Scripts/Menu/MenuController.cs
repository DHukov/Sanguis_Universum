using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public UnityEvent SaveUnit;
    public UnityEvent LoadUnit;
    public GameObject settings;
    public void StartGame()
    {
        LoadUnit.Invoke();

    }

    public void LoadGame()
    {
        LoadUnit.Invoke();
    }

    public void Settings()
    {
        settings.SetActive(!settings.activeSelf);
    }

    public void NewGame()
    {
        Application.LoadLevel(10);

        SaveUnit.Invoke();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    
}