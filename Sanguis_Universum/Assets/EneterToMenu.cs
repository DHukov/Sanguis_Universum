using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneterToMenu : MonoBehaviour
{

    public float TimeToMenu;
    private void Start() { StartCoroutine(ToMenu()); }
    private void Update()
    {
        StartCoroutine(ToMenu());
        if (Input.GetKeyDown(KeyCode.Space))
            this.GetComponent<SwitcherOfScenes>().Teleport();
    }
    private IEnumerator ToMenu()
    {
        yield return new WaitForSeconds(TimeToMenu);
        this.GetComponent<SwitcherOfScenes>().Teleport();
    }
}
