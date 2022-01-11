using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilenceMechanik : MonoBehaviour
{
    [SerializeField] GameObject player;

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
        if(player.GetComponent<Hiding>().hiding == true)
        {
            TimeForDo -= Time.deltaTime;
            //Debug.Log(WasteTime);
            if (Input.GetKeyDown(KeyCode.Space) || TimeForDo <= 0 )
            {
                add_list.Add(1);
                Debug.LogError("mouse");
                if (add_list[MaxClicks] <= MaxClicks)
                {
                    add_list.Clear();
                    player.GetComponent<Hiding>().NotHiding();
                    TimeForDo = 2;
                }
            }
        }
    }

}
