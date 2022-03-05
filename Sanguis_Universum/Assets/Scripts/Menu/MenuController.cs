using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public UnityEvent SaveUnit;
    public UnityEvent LoadUnit;
    public GameObject settings;
    public void NewGame()
    {
        StartCoroutine(NewScene());
    }
    IEnumerator NewScene()
    {
        AsyncOperation AsyncLoad = SceneManager.LoadSceneAsync(1);
        while (!AsyncLoad.isDone)
            yield return null;
    }
    public void LoadGame() { LoadUnit.Invoke(); }
    public void Settings() { settings.SetActive(!settings.activeSelf); }
    public void ExitGame() { Application.Quit(); }    
}