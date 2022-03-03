using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public UnityEvent SaveUnit;
    public UnityEvent LoadUnit;
    public GameObject settings;
    public void NewGame()
    {

        StartCoroutine(NewScene());

        //SaveUnit.Invoke();
    }
    IEnumerator NewScene()
    {
        AsyncOperation AsyncLoad = SceneManager.LoadSceneAsync(1);
        //anim.SetTrigger("Fade");
        while (!AsyncLoad.isDone)
        {
            yield return null;
            //_player.GetComponent<PlayerStats>().LoadPlayerStats();

        }
    }

    public void LoadGame()
    {
        LoadUnit.Invoke();
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