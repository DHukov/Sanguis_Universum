using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilenceMechanik : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    public bool enemyClose;

    bool CatchTheTime;
    public int MaxClicks;
    public float TimeForDo;

    public float WasteTime;
    public List<int> clickList = new List<int>();

    public void Update()
    {
        OneClick2();
        if (enemy.GetComponent<CircleCollider2D>().IsTouching(this.GetComponent<CircleCollider2D>()))
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
            //Debug.Log(enemyClose);
            this.GetComponent<Interaction>().AccesToKey = false;
            TimeForDo -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.T))
            {
                clickList.Add(1);
                Debug.LogError("YouAreInSafe");
            }
            if (TimeForDo <= 0 && CatchTheTime == false)
            {
                player.GetComponent<Hiding>().NotHiding();
            }
            else if (clickList[9] <= MaxClicks)
            {
                //enemy.GetComponent<Enemy_Patrol>().GetNextTarget();
                enemy.GetComponent<AI3>().enabled = false;
                player.GetComponent<Hiding>().patrolState = true;
                CatchTheTime = true;
                PressOneMore();
                TimeForDo = 2;
            }
        }
        else
            ParametresNotHid();

    }

    /*

    public void OneClick()
    {

        //Player.GetComponent<Hiding>().hiding == true
        if (player.GetComponent<Hiding>().hiding == true)
        {
            //this.GetComponent<Interaction>().AccesToKey = false;
            TimeForDo -= Time.deltaTime;
            Debug.Log(player.GetComponent<Hiding>().hiding);
            if (Input.GetKeyDown(KeyCode.T))
            {
                clickList.Add(1);
                Debug.LogError("YouAreInSafe");
            }
            if (TimeForDo <= 0 && CatchTheTime == false)
            {
                player.GetComponent<Hiding>().NotHiding();
            }
            else if(clickList[9] <= MaxClicks)
            {



            }
        }
        else
            ParametresNotHid();
    }
    */
    void ParametresNotHid()
    {
        this.GetComponent<Interaction>().AccesToKey = true;

        CatchTheTime = false;
        clickList.Clear();
        TimeForDo = 2;
    }
    void PressOneMore()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            player.GetComponent<Hiding>().NotHiding();
        }
    }
}
