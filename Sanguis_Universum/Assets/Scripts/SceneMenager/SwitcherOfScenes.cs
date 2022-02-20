using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine;


public class SwitcherOfScenes : MonoBehaviour
{
    public Animator anim;
    
    [SerializeField] PlayerStats Key;
    [SerializeField] string m_SceneName;
    [SerializeField] GameObject Interaction;


    public UnityEvent SaveUnit;
    public UnityEvent LoadUnit;

    void Start()
    {
        anim = GetComponent<Animator>();
            LoadUnit.Invoke();
        //Debug.LogError(Key.GetComponent<PlayerStats>().key1);
    }
    public void IsOpened()
    {

        if (Key.GetComponent<PlayerStats>().key1 == true)
        {
            Teleport();
        }
        else
            Interaction.GetComponent<Interaction>().AccesToKey = true;

    }

    public void Teleport()
    {
        SaveUnit.Invoke();
        StartCoroutine(LoadScene());
    }


    IEnumerator LoadScene()
    {
        AsyncOperation AsyncLoad = SceneManager.LoadSceneAsync(m_SceneName);
        anim.SetTrigger("Fade");
        while (!AsyncLoad.isDone)
        {
            yield return null;
        }

    }
}
/*
public void IsOpened(GameObject obj)
{
    if (!isOpened)
    {
        PlayerStats manager = obj.GetComponent<PlayerStats>();
        if (manager.key1)
        {
            isOpened = true;
            manager.useKey1();
            Debug.Log("FBIopened the door");
        }
        else
        {
            Debug.Log("Nie otwarte");
        Message.SetActive(true);
        }
    }
    else
    {
        Message.SetActive(false);
    }
}
*/