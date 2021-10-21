using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine;


public class SwitcherOfScenes : MonoBehaviour
{
    public GameObject Message;
    public VectorValue PlayerStorage;
    public Vector3 position;
    [SerializeField] string m_SceneName;
    public float spaceHoldingTime = 0;
    [SerializeField] float time;

    public PlayerStats Key;

    private bool HasPlayer;
    public KeyCode KeyToScene;

    public Animator anim;
    public bool isOpened;

    public UnityEvent SaveUnit;
    public UnityEvent LoadUnit;


    void Start()
    {
        anim = GetComponent<Animator>();
            LoadUnit.Invoke();

    }


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
    public void Teleport()
    {
        if (isOpened)
        {
            SaveUnit.Invoke();
            
            StartCoroutine(LoadScene());
            //Invoke("LoadUnit", 2);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        if (collision.CompareTag("Player"))
        {
            HasPlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
        if (collision.CompareTag("Player"))
        {
            HasPlayer = false;
        }
    }

    IEnumerator CountPressTimeCoroutine()
    {
        while (true)
        {
            if (Input.GetKey(KeyToScene))
                spaceHoldingTime += Time.deltaTime;
            else if (spaceHoldingTime > 0)
                OnSpaceReleased();
            yield return null;
        }
    }

    void OnSpaceReleased()
    {
        Debug.Log(spaceHoldingTime);
        spaceHoldingTime = 0;
    }
    IEnumerator LoadScene()
    {
        AsyncOperation AsyncLoad = SceneManager.LoadSceneAsync(m_SceneName);
        anim.SetTrigger("FadeOut");
        while (!AsyncLoad.isDone)
        {
            yield return null;
        }
    }
}