using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = PlayerMovement.instance.gameObject;
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 0.1f, player.transform.position.z);
        transform.LookAt(transform.up);
    }
}
