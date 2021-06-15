using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;
    private int cubeCount;

    private void Start()
    {
        player = PlayerMovement.instance.gameObject;
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        cubeCount = player.transform.childCount;

        Vector3 unitVector = transform.forward * cubeCount;

        Vector3 pos = player.transform.position + offset - unitVector;
        pos.y = 13f + cubeCount/2;                 // y ekseninde kamera sabit


        //transform.position = pos;

        // Lerp kullaninca zoom in ve zoom out daha smooth gerceklesiyor
        transform.position = Vector3.Lerp(transform.position, pos, .3f);
    }
}
