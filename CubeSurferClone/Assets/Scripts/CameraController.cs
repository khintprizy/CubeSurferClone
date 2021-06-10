using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;
    private float offsetX;
    private float offsetY;
    private float offsetZ;

    private void Start()
    {
        player = PlayerMovement.instance.gameObject;
        offsetX = transform.position.x - player.transform.position.x;
        offsetY = transform.position.y - player.transform.position.y;
        offsetZ = transform.position.z - player.transform.position.z;
        //offset = new Vector3(offsetX, offsetY, offsetZ);
    }

    private void LateUpdate()
    {
        //transform.position = new Vector3(player.transform.position.x, posY, player.transform.position.z);
        transform.position = new Vector3(player.transform.position.x + offsetX, offsetY, player.transform.position.z + offsetZ);
    }
}
