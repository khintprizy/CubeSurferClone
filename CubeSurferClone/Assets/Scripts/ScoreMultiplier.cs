using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
    [SerializeField]
    private int _multiplyValue;
    public int multiplyValue
    {
        get
        {
            return _multiplyValue;
        }
        set
        {
            _multiplyValue = value;
        }
    }

}
