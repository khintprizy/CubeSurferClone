using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;

    private void Start()
    {
        player = PlayerMovement.instance.gameObject;
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 pos = player.transform.position + offset;
        pos.y = 15f;                 // y ekseninde kamera sabit
        transform.position = pos;
    }
}
