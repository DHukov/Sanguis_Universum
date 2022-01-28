using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilenceMechanik : MonoBehaviour
{
    [SerializeField] GameObject Player;

    bool CatchTheTime;
    public int MaxClicks;
    public float TimeForDo;

    public float WasteTime;
    public List<int> add_list = new List<int>();


    void Update() => OneClick();

    void OneClick()
    {
                add_list.Add(1);
        if (Player.GetComponent<Hiding>().hiding == true)
        {
            this.GetComponent<Interaction>().AccesToKey = false;
            TimeForDo -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.T))
            {
                add_list.Add(1);
                Debug.LogError("YouAreInSafe");
            }
            if (TimeForDo <= 0 && CatchTheTime == false)
            {
                Player.GetComponent<Hiding>().NotHiding();
            }
            else if(add_list[MaxClicks] <= MaxClicks)
            {
                CatchTheTime = true;
                PressOneMore();
            }
        }
        else
            ParametresNotHid();
    }
    void ParametresNotHid()
    {
        this.GetComponent<Interaction>().AccesToKey = true;

        CatchTheTime = false;
        add_list.Clear();
        TimeForDo = 2;
    }
    void PressOneMore()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Player.GetComponent<Hiding>().NotHiding();
        }
    }
}
