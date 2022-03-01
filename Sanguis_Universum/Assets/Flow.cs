using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flow : MonoBehaviour
{
    float time;
    public GameObject _stars;
    public GameObject _clouds;
    public GameObject _moon;

    public float _multiply = 1;
    public float _multiply_stars = 1;
    public float _multiply_moon = 1;



    void Update()
    {
        time = Time.time;
        _moon.transform.position = new Vector3(2290 - time * _multiply_moon, 1860, 10000);
        _stars.transform.position = new Vector3(32228- time* _multiply_stars, 30, 10000);
        _clouds.transform.position = new Vector3(0 - time * _multiply, 0, 0);

    }
}
