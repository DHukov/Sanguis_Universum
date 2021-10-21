using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject
{
    public Vector3 initialValue, scaleValue, newValue;
    public float[] Pos;

    void PositionArray()
    {
        Pos = new float[3];
        Pos[0] = newValue.x;
        Pos[1] = newValue.y;
        Pos[2] = newValue.z;
    }
}