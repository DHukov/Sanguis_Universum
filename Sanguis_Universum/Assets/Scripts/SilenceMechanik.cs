using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilenceMechanik : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Press_Button;
    [SerializeField] GameObject SafetyText;

    bool CatchTheTime;
    public int MaxClicks;
    public float TimeForDo;

    public float WasteTime;
    public List<int> add_list = new List<int>();

    void Update()
    {
        OneClick();
    }

    void OneClick()
    {
        if (Player.GetComponent<Hiding>().hiding == true)
        {
            TimeForDo -= Time.deltaTime;
            this.GetComponent<Interaction>().enabled = false;
            Press_Button.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                add_list.Add(1);
                Debug.LogError("mouse");
            }
            if (TimeForDo <= 0 && CatchTheTime == false)
            {
                Player.GetComponent<Hiding>().NotHiding();
            }
            else if(add_list[MaxClicks] <= MaxClicks)
            {
                CatchTheTime = true;
                //add_list.Clear();
                PressOneMore();
            }
        }
        else
            ParametresNotHid();
    }
    void ParametresNotHid()
    {
        CatchTheTime = false;
        SafetyText.SetActive(false);
        Press_Button.SetActive(false);
        this.GetComponent<Interaction>().enabled = true;
        add_list.Clear();
        TimeForDo = 2;
    }
    void PressOneMore()
    {
        Press_Button.SetActive(false);
        SafetyText.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            Player.GetComponent<Hiding>().NotHiding();
        }
    }
}
