using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        float posY = 2.5f;
        transform.position = new Vector3(player.transform.position.x, posY, player.transform.position.z);
    }
}
