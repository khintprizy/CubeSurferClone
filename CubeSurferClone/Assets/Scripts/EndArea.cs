using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.singleton.RestartGame();
    }
}
