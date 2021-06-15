using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndArea : MonoBehaviour
{
    GameManager gameManager;
    UIManager uiManager;

    private void Start()
    {
        gameManager = GameManager.instance;
        uiManager = UIManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.mainCubeTag) || other.gameObject.CompareTag(Tags.playerGFXTag))
        {
            uiManager.CalculateAndAddToTotal(5);     // final alanina geldiginde 5x e carpmis gibi puan ekleniyor
            gameManager.GameWin();
        }
    }
}
