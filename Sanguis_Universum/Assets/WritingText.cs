using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WritingText : MonoBehaviour
{
    public float _text_speed;
    public string _text;
    private string current_text = "";
    private void Start()
    {
        StartCoroutine(ShowText());
    }
    IEnumerator ShowText()
    {
        for(int i = 0; i < current_text.Length; i++)
        {
            current_text = _text.Substring(0, i);
            this.GetComponent<Text>().text = current_text;
            yield return new WaitForSeconds(_text_speed);
        }
    }
}
