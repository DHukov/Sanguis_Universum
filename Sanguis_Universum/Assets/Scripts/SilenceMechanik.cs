using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilenceMechanik : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject _interface;
    [SerializeField] GameObject _interface_Time;
    [SerializeField] GameObject _interface_Progress;
    public GameObject _inter;

    public bool enemyClose;

    bool CatchTheTime;
    public int MaxClicks;
    public float TimeForDo;

    public float WasteTime;
    public List<int> clickList = new List<int>();

    public void Update()
    {
        OneClick2();
        if (_inter.layer == enemy.layer)
        {
            enemyClose = true; 
        }
        else
            enemyClose = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("touch");
        if (collision.gameObject.layer == enemy.layer)
        {
            enemyClose = true;

        }
        else
            enemyClose = false;
    }

    public void OneClick2()
    {
        if (enemyClose && player.GetComponent<Hiding>().hiding == true)
        {
            _interface.gameObject.SetActive(true);
            _interface_Time.GetComponent<Image>().fillAmount = (2 - TimeForDo) / 2;

            
            //_inter.GetComponent<Interaction>().AccesToKey = false;
            TimeForDo -= Time.deltaTime;
            //loadTime.fillAmount = (2 - TimeForDo) / 2;

            if (Input.GetKeyDown(KeyCode.T))
            {
                _interface_Progress.GetComponent<Image>().fillAmount += 0.1f;

                clickList.Add(1);
            }
            if (TimeForDo <= 0 && CatchTheTime == false)
            {
                player.GetComponent<Hiding>().NotHiding();
            }
            else if (clickList[9] <= MaxClicks)
            {  
                _interface.gameObject.SetActive(false);

                enemy.GetComponent<AI3>().enabled = false;
                player.GetComponent<Hiding>().patrolState = true;
                CatchTheTime = true;
                PressOneMore();
                TimeForDo = 2;

                _interface_Time.GetComponent<Image>().fillAmount = 0;
                _interface_Progress.GetComponent<Image>().fillAmount = 0;
            }
        }
        else
            ParametresNotHid();
    }

    void ParametresNotHid()
    {
        _interface.gameObject.SetActive(false);
        //_inter.GetComponent<Interaction>().AccesToKey = true;

        _interface_Time.GetComponent<Image>().fillAmount = 0;
        _interface_Progress.GetComponent<Image>().fillAmount = 0;

        CatchTheTime = false;
        clickList.Clear();
        TimeForDo = 2;
    }
    void PressOneMore()
    {
        if (Input.GetKeyDown(KeyCode.E))
            player.GetComponent<Hiding>().NotHiding();
    }
}
