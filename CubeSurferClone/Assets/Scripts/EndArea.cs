using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndArea : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.RestartGame();
    }
}
