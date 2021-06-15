using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSurface : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.mainCubeTag))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag(Tags.playerGFXTag))
        {
            gameManager.GameWin();
        }
    }
}
