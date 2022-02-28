using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public GameObject settings;
    public void StartGame()
    {
      Application.LoadLevel(3);
    }

    public void LoadGame()
    {
        
    }

    public void Settings()
    {
        settings.SetActive(!settings.activeSelf);
    }

    

    public void ExitGame()
    {
        Application.Quit();
    }

    
}