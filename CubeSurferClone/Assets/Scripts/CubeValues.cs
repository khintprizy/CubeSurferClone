using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cube Values", menuName = "Scriptable Objects/Cube Values")]
public class CubeValues : ScriptableObject
{
    public float addToPlayerPos;
    public float distanceBetweenLastChild;
}
