using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSurface : MonoBehaviour
{
    GameManager gameManager;
    CameraController camController;
    Trail trail;
    PlayerMovement player;

    private void Start()
    {
        gameManager = GameManager.instance;
        camController = CameraController.instance;
        player = PlayerMovement.instance;
        trail = FindObjectOfType<Trail>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.mainCubeTag))
        {
            //Calculate Trail position
            // 2 nin nedeni: eger en son child a parent edersek trail da onunla birlikte destroy olacak.
            trail.CalculateTrailPosition(2);

            Destroy(other.gameObject);
            //ChangeZoom
            camController.ChangeZoom();

        }
        if (other.gameObject.CompareTag(Tags.playerGFXTag))
        {
            gameManager.GameWin();
        }
    }
}
